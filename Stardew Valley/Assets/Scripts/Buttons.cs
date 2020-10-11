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

    void PurchaseItem(int _itemID, int _itemPrice)
    {
        Inventory.instance.GetAnItem(_itemID);
        Database.instance.ChangeGold(-_itemPrice);
    }

    public void BtnPurchase()
    {
        if(itemType == Item.ItemType.Seed)
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
        else if(itemType == Item.ItemType.Food)
        {
            if(Database.instance.gold >= itemPrice)
            {
                if (itemCode == 20001)
                {
                    //if(Inventory.instance.inventoryItemList)
                }
                else if (itemCode == 20002) //커피
                {
                    PurchaseItem(itemCode, itemPrice);
                }
            }
            else
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "MatShortage_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
        }
    }
}
