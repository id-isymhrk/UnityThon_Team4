using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAppear : MonoBehaviour
{
    private const int MaxItems = 3;

    [SerializeField] int difficullty = 0;
    [SerializeField] int getNum = 0;

    [SerializeField] GameObject[] item = new GameObject[MaxItems];
    [SerializeField] GameObject[] point = new GameObject[MaxItems];

    private bool[] itemFlag = new bool[MaxItems] { false, false, false };
    private GameObject[] gameItems = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        switch (difficullty)
        {
            case 0:
                gameItems[0] = (GameObject)Instantiate(item[0], point[0].transform.position, point[0].transform.rotation);
                break;
            case 1:
                for (int i = 0; i < item.Length; i++)
                {
                    gameItems[i] = (GameObject)Instantiate(item[i], point[i].transform.position, point[i].transform.rotation);
                }
                break;
            case 2:
                gameItems[getNum] = (GameObject)Instantiate (item[getNum], point[getNum].transform.position, point[getNum].transform.rotation);
                itemFlag[getNum] = true;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (difficullty == 2)
        {
            //checkDestroy
            if (gameItems[getNum] == null)
            {
                getNum++;
            }
            //checkInstantiate
            if (!itemFlag[getNum])
            {
                gameItems[getNum] = (GameObject)Instantiate(item[getNum], point[getNum].transform.position, point[getNum].transform.rotation);
                itemFlag[getNum] = true;
            }
        }
        debug();
    }

    void debug()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameItems[getNum]);
            Debug.Log("Down Space");
        }
    }
}
