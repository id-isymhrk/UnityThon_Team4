// 取得可能クラス
using UnityEngine;
using System;
 
[Serializable]
public class Obtainable
{
    [SerializeField] string itemName;
    [SerializeField] string itemId;
    GameObject gameObject;
 
    internal void Obtain(GameObject item)
    {
        gameObject = item;
        Inventory.GetInstance().Obtain(this);
    }
 
    internal string GetItemName()
    {
        return itemName;
    }
    
    internal string GetItemId()
    {
        return itemId;
    }
    internal GameObject GetGameObject()
    {
        return gameObject;
    }
}