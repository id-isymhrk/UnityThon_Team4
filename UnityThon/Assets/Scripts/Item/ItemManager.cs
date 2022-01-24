using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ItemManager : MonoBehaviour {
 
    static ItemManager instance;
	//　アイテムデータベース
	[SerializeField]
	private ItemDataBase itemDataBase;
	//　アイテム数管理
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();
 
	// Use this for initialization
	void Start () 
    {
        instance = this;//シーン上のインスタンスを静的フィールドに入れる
    }
    //インスタンスを返す
    public static ItemManager GetInstance()
    {
        return instance;
    }
 
	//　名前でアイテムを取得
	public Item GetItem(string searchName) 
    {
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
    public bool HasItem(string searchName)
    {
        return itemDataBase.GetItemLists().Exists(item => item.GetItemName() == searchName);
    }
}