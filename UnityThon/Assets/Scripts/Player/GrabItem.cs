using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItem : MonoBehaviour
{
    public AudioClip taking;
    private AudioSource _audioSource;
    public GameObject cam;//プレイヤーのメインカメラ
    public float limitGrabDistance = 3f;//(掴む)選択する距離
    // private LineRenderer lineRenderer;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        // lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.startWidth = 0.1f;
        // lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //開発用のラインレンダラー 後で消す
        // lineRenderer.SetPosition(0, cam.transform.position + cam.transform.up * -0.1f);
        // lineRenderer.SetPosition(1, cam.transform.position + cam.transform.forward * limitGrabDistance);

        //レイキャスト飛ばしてアイテムを検出する
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, limitGrabDistance, ~(1 << 10)))
        {
            if(hit.collider.tag == "Item")
            {
                if (hit.collider.gameObject.TryGetComponent(out ISelectable c))
                {
                    // クリックされた時の処理
                    c.Selected();
                }
                if(Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IGrabbable g))
                    {
                        // クリックされた時の処理
                        g.Grabble();
                        //_audioSource.PlayOneShot(taking);
                    }
                }
            }
        }
    }
}
