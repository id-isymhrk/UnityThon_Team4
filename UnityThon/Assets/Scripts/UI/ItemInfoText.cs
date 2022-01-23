using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoText : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> TextUIs = new List<GameObject>();
    public static ItemInfoText instance;
    public static ItemInfoText GetInstance()
    {
        return instance;
    }
    public void SetText(string text, int index)
    {
        GameObject textUI = TextUIs[index];
        textUI.GetComponent<Text>().text = text;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        TextUIs.ForEach(UI=>
        {
            UI.GetComponent<Text>().text = "";
        });
    }
}
