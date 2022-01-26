using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float x, z;
    public float speed = 0.05f;//通常時の歩くスピード
    public float runningSpeed = 0.13f;//走っているときのスピード
    public float junpForce = 100f;//ジャンプ力


    public GameObject cam;//プレイヤー視点
    Quaternion cameraRot, characterRot;

    public float Xsensityvity = 3f, Ysensityvity = 3f;//マウス感度
    bool cursorLock = true;

    //Event
    public UnityEvent OnGameOver;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    private bool isGround = false; //着地判定
    private bool jumpFlag = false;//地面接してる時スペース押したらtrue
    private Rigidbody rigidbody;
    
    public AudioClip moving;
    private AudioSource _audioSource;

    [SerializeField]
    GameObject rebornPoint;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource=this.GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
        if(isGround){
            if(Input.GetKeyDown(KeyCode.Space))
            {
                jumpFlag = true;
                isGround = false;
            }
        }

        UpdateCursorLock();


        PlayerReborn();

        //移動中におけるse再生の管理
        if (!rigidbody.IsSleeping()&&!_audioSource.isPlaying)_audioSource.PlayOneShot(moving);
        else if(rigidbody.IsSleeping())_audioSource.Stop();
    }

    private void PlayerReborn()
    {
        if (this.transform.position.y < 0)
        {
            this.transform.position = rebornPoint.transform.position;
        }
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;
        float playerSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = runningSpeed;
        }

        x = Input.GetAxisRaw("Horizontal") * playerSpeed;
        z = Input.GetAxisRaw("Vertical") * playerSpeed;

        //transform.position += new Vector3(x,0,z);

        transform.position += cam.transform.forward * z + cam.transform.right * x;
        if(jumpFlag){
            rigidbody.AddForce(0, junpForce, 0);
            jumpFlag = false;
        }
    }


    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if(Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX,minX,maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
    void OnCollisionEnter(Collision other) //地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground") //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
        }
        if(other.gameObject.tag == "Enemy")
        {
            //OnGameOver?.Invoke();
            SceneManager.LoadScene("GameOver");
        }
        if(other.gameObject.tag == "Door")
        {
            if (Inventory.GetInstance().GetHasItemNum() == ItemAppear.GetInstance().GetItemsNum())
            {
                //ChangeScene
                SceneManager.LoadScene("Game Clare");
            }
        }
    }
}
