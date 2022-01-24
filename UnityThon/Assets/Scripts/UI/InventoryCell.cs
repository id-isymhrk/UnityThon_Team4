using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetUp(string name)
    {
        if(name == "null")
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            image.sprite = null;
            return;
        }
        image = GetComponent<Image>();
        image.sprite = ItemManager.GetInstance().GetItem(name).GetIcon();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }
}
