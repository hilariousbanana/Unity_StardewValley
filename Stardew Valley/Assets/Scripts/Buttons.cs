using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public int itemCode;
    public int itemPrice;
    public Item.ItemType itemType;
    public Image noticePanel;

    public int matCode1 = 0;
    public int matCode2 = 0;
    public int matCode3 = 0;
    public int matCount1 = 0;
    public int matCount2 = 0;
    public int totalCount = 0;
    public int[] slots;

    private void Start()
    {
        totalCount = matCount1 + matCount2 - 1;
        if(itemCode == 30001)
        {
            totalCount = 2;
        }
        slots = new int[totalCount];
    }

    void PurchaseItem(int _itemID, int _itemPrice)
    {
        Inventory.instance.GetAnItem(_itemID);
        Database.instance.ChangeGold(-_itemPrice);
    }

    public void BtnPurchase()
    {
        if (itemType == Item.ItemType.Seed) //씨앗상점
        {
            if (Database.instance.gold >= itemPrice)
            {
                PurchaseItem(itemCode, itemPrice);
            }
            else
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "GoldShortage_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
        }
        else if (itemType == Item.ItemType.Food)//음식상점
        {
            if (Database.instance.gold >= itemPrice)
            {
                if (itemCode == 30002)
                {
                    PurchaseItem(itemCode, itemPrice);
                }
                else if (itemCode == 30001)
                {
                    for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++) // 인벤토리에 같은 아이템이 있는지 검색
                    {
                        if (Inventory.instance.inventoryItemList[i].itemID == matCode1 && totalCount != 0) //있을 경우
                        {
                            slots[totalCount] = i;
                            totalCount--;
                        }
                        else if (Inventory.instance.inventoryItemList[i].itemID == matCode2 && totalCount != 0)
                        {
                            slots[totalCount] = i;
                            totalCount--;
                        }
                        else if(Inventory.instance.inventoryItemList[i].itemID == matCode3 && totalCount !=0)
                        {
                            slots[totalCount] = i;
                            totalCount--;
                        }
                    }
                    if (totalCount == 0)//조건충족
                    {
                        for (int i = 0; i < slots.Length; i++)
                        {
                            Inventory.instance.inventoryItemList[slots[i]].itemCount--;
                        }
                        Inventory.instance.GetAnItem(itemCode);
                    }
                    Inventory.instance.UpdateItem();
                }
            }
            else
            {
                for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++) // 인벤토리에 같은 아이템이 있는지 검색
                {
                    if (Inventory.instance.inventoryItemList[i].itemID == matCode1 && matCount1 != 0) //있을 경우
                    {
                        slots[totalCount] = i;
                        totalCount--;
                        matCount1--; //슬롯에 갯수만 증가.
                    }
                    else if (Inventory.instance.inventoryItemList[i].itemID == matCode2 && matCount2 != 0)
                    {
                        slots[totalCount] = i;
                        totalCount--;
                        matCount2--;
                    }
                }
                if (matCount1 == 0 && matCount2 == 0)//조건충족
                {
                    for (int i = 0; i < slots.Length; i++)
                    {
                        Inventory.instance.inventoryItemList[i].itemCount--;
                    }
                    Inventory.instance.GetAnItem(itemCode);
                }
                Inventory.instance.UpdateItem();
            }
        }
        else if (itemCode == 30002)
        {
            noticePanel.sprite = Resources.Load("Sprites/" + "GoldShortage_Notice", typeof(Sprite)) as Sprite;
            noticePanel.gameObject.SetActive(true);
        }
        else
        {
            noticePanel.sprite = Resources.Load("Sprites/" + "MatShortage_Notice", typeof(Sprite)) as Sprite;
            noticePanel.gameObject.SetActive(true);
        }
    }
}
