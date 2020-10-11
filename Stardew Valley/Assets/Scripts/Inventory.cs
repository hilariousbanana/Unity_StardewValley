using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private InventorySlot[] slots;
    public Image[] chosenBoxes;

    private List<Item> inventoryItemList;

    public Transform tf;

    private int selectedItem;
    private int selectedTab;

    private bool itemActivated;
    private bool stopKeyInput;
    private bool preventExec;

    private WaitForSeconds waitTime = new WaitForSeconds(0.0f);

    private void Start()
    {
        instance = this;

        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
    }

    
    private void Update()
    {

    }

    public void UpdateItem()
    {
        for(int i = 0; i < inventoryItemList.Count; i++)
        {
            slots[i].AddItem(inventoryItemList[i]);
        }
    }

    public void GetAnItem(int _itemID, int _itemCount = 1)
    {
        for(int i = 0; i < Database.instance.itemList.Count; i++) //데이터 베이스에 아이템 검색
        {
            if(_itemID == Database.instance.itemList[i].itemID) // 데이터 베이스에서 해당 종류 아이템 발견
            {
                for(int j = 0; j < inventoryItemList.Count; j++) // 인벤토리에 같은 아이템이 있는지 검색
                {
                    if(inventoryItemList[j].itemID == _itemID) //있을 경우
                    {
                        inventoryItemList[j].itemCount += _itemCount; //슬롯에 갯수만 증가.
                        UpdateItem();
                        return;
                    }    
                }
                inventoryItemList.Add(Database.instance.itemList[i]); //없을경우 새로 추가
                UpdateItem();
                return;
            }
        }
    }
}
