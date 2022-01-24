using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "ItemDataBase", menuName="CreateItemDataBase")]
public class ItemDataBase : ScriptableObject {
 
	[SerializeField]
	private List<Item> itemLists = new List<Item>();
 
	//　アイテムリストを返す
	public List<Item> GetItemLists() {
		return itemLists;
	}
}