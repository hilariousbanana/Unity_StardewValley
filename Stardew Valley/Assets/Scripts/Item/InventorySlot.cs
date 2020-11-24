using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public GameObject chosenBox;
    public Image noticePanel;
    public Text itemCount_Text;
    public Text slotNumber_Text;
    public Transform pos;
    public bool usable = false;
    public int slotNumber;


    public void Clicked()
    {
        if(Inventory.instance.isEmpty == false)
        {
            DataController.instance.data.chosenSlot = slotNumber;
            usable = true;
            chosenBox.transform.SetParent(pos.gameObject.transform);
            chosenBox.transform.position = pos.position;
            //Debug.Log("Clicked. at" + slotNumber);
            if(DataController.instance.data.sellEnabled)
            {
                 switch(Inventory.instance.inventoryItemList[slotNumber].itemID)
                {
                    case 20001:
                        SellItem(slotNumber, 200);
                        break;
                    case 20002:
                        SellItem(slotNumber, 250);
                        break;
                    case 20003:
                        SellItem(slotNumber, 150);
                        break;
                    case 20004:
                        SellItem(slotNumber, 150);
                        break;
                    case 20005:
                        SellItem(slotNumber, 80);
                        break;
                    case 30001:
                        SellItem(slotNumber, 350);
                        break;
                    case 30002:
                        SellItem(slotNumber, 480);
                        break;
                    case 30003:
                        SellItem(slotNumber, 720);
                        break;
                    case 30004:
                        SellItem(slotNumber, 180);
                        break;
                    case 30005:
                        SellItem(slotNumber, 770);
                        break;
                }
            }
            else if(DataController.instance.data.sellEnabled == false)
            {
                switch (Inventory.instance.inventoryItemList[slotNumber].itemID)
                {
                    case 20001:
                        ItemEffect(slotNumber, 8);
                        break;
                    case 20002:
                        ItemEffect(slotNumber, 15);
                        break;
                    case 20003:
                        ItemEffect(slotNumber, 5);
                        break;
                    case 20004:
                        ItemEffect(slotNumber, 5);
                        break;
                    case 20005:
                        ItemEffect(slotNumber, 3);
                        break;
                    case 30001:
                        ItemEffect(slotNumber, 25);
                        break;
                    case 30002:
                        ItemEffect(slotNumber, 0.05f);
                        break;
                    case 30003:
                        ItemEffect(slotNumber, 50);
                        break;
                    case 30004:
                        ItemEffect(slotNumber, 15);
                        break;
                    case 30005:
                        ItemEffect(slotNumber, 50);
                        break;
                }
            }
        }
    }

    private void Update()
    {
        slotNumber_Text.text = slotNumber.ToString();
    }

    public void AddItem(Item _item)
    {
        Color temp = icon.color;
        temp.a = 1.0f;
        icon.sprite = _item.itemIcon;
        icon.color = temp;

        if (_item.itemCount > 0)
        {
            itemCount_Text.text = _item.itemCount.ToString();
        }
        else
            itemCount_Text.text = string.Empty;
    }

    public void RemoveItem()
    {
        itemCount_Text.text = string.Empty;
        icon.sprite = null;
        Color temp = icon.color;
        temp.a = 0.0f;
        icon.color = temp;
    }

    public void InitSlot()
    {
        icon.sprite = DataController.instance.data.inventory[slotNumber].itemIcon;
    }

    void SellItem(int _slotNum, int _gold)
    {
        Inventory.instance.UseAnItem(_slotNum);
        DataController.instance.data.ChangeGold(_gold);
    }

    void ItemEffect(int _slotNum, float _hp)
    {
        if(Inventory.instance.inventoryItemList[slotNumber].itemID == 30002 && !DataController.instance.data.coffeeDrink)
        {
            if(!DataController.instance.data.coffeeDrink)
            {
                Inventory.instance.UseAnItem(_slotNum);
                DataController.instance.data.ChangeSpeed(DataController.instance.data.runSpeed);
                DataController.instance.data.coffeeDrink = true;
            }
            else
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "CoffeeUsage_Notice", typeof(Sprite)) as Sprite;
            }
        }
        else
        {
            Inventory.instance.UseAnItem(_slotNum);
            DataController.instance.data.ChangeHP((int)_hp);
        }
    }
}
