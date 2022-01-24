using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    static Inventory instance;
    [SerializeField]
    private List<GameObject>CellList = new List<GameObject>();
    private List<Obtainable>inventory = new List<Obtainable>();
    int maxInventoryItem = 5;//初期値
    public static Inventory GetInstance()
    {
        return instance;
    }

    public int GetHasItemNum()
    {
        return inventory.Count;
    }

    public List<Obtainable> SearchInventoryName(string name)
    {
        List<Obtainable> result = new List<Obtainable>();
        for(int i=0; i<inventory.Count; i++)
        {
            if(inventory[i].GetItemName() == name)
            {
                result.Add(inventory[i]);
            }
        }
        return result;
    }
    public List<Obtainable> SearchInventoryId(string id)
    {
        List<Obtainable> result = new List<Obtainable>();
        for(int i=0; i<inventory.Count; i++)
        {
            if(inventory[i].GetItemId() == id)
            {
                result.Add(inventory[i]);
            }
        }
        return result;
    }
    public void Obtain(Obtainable item)
    {
        if(ItemManager.GetInstance().HasItem(item.GetItemName()))
        {
            Push2Inventory(item);
        }
    }
    private void Push2Inventory(Obtainable item)
    {
        if(inventory.Count >= maxInventoryItem)
        {
            
        }
        else
        {
            inventory.Add(item);
            item.GetGameObject().SetActive(false);
            DrawingUI();
        }
    }
    private void deleteItemInInventory(string id)
    {
        for(int i=0; i<inventory.Count; i++)
        {
            if(inventory[i].GetItemId() == id)
            {
                inventory.RemoveAt(i);
            }
        }
    }
    private void DrawingUI()
    {
        for(int i=0; i<CellList.Count; i++){
            InventoryCell cell = CellList[i].GetComponent<InventoryCell>();
            string itemName;
            if(i >= inventory.Count)
            {
                itemName = "null";
            }
            else
            {
                itemName = inventory[i].GetItemName();
            }
            cell.SetUp(itemName);
        }
    }
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxInventoryItem = CellList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
