using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int slotIndex = 0;
    public bool canBuy = false;
    bool isChecked1 = false;
    bool isChecked2 = false;
    bool isChecked3 = false;
    int matSlot1;
    int matSlot2;

    private void Start()
    {
        if (itemType == Item.ItemType.Food)
        {
            slots = new int[2];
        }
    }

    void PurchaseItem(int _itemID, int _itemPrice)
    {
        Inventory.instance.GetAnItem(_itemID);
        Database.instance.ChangeGold(-_itemPrice);
    }

    public void BtnPurchase()
    {
        AudioManager.instance.Play("Click");
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
                CheckConditions();
            }
            else if (itemCode == 30002)
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "GoldShortage_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
            ResetArray();
        }
    }

    void CheckConditions()
    {
        if (itemCode == 30001) //샐러드
        {
            for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++)
            {
                if (Inventory.instance.inventoryItemList[i].itemID == matCode1 && totalCount != 0) //컬리플라워
                {
                    if (Inventory.instance.inventoryItemList[i].itemCount >= 2)
                    {
                        Inventory.instance.UseAnItem(i);
                        Inventory.instance.UseAnItem(i);
                        canBuy = true;
                        break;
                    }
                    else if (Inventory.instance.inventoryItemList[i].itemCount == 1 && !isChecked1)
                    {
                        slots[slotIndex] = i;
                        slotIndex++;
                        totalCount--;
                        isChecked1 = true;
                    }
                }
                else if (Inventory.instance.inventoryItemList[i].itemID == matCode2 && totalCount != 0) //감자
                {
                    if (Inventory.instance.inventoryItemList[i].itemCount >= 2)
                    {
                        Inventory.instance.UseAnItem(i);
                        Inventory.instance.UseAnItem(i);
                        canBuy = true;
                        break;
                    }
                    else if (Inventory.instance.inventoryItemList[i].itemCount == 1 && !isChecked2)
                    {
                        slots[slotIndex] = i;
                        slotIndex++;
                        totalCount--;
                        isChecked2 = true;
                    }
                }
                else if (Inventory.instance.inventoryItemList[i].itemID == matCode3 && totalCount != 0) //케일
                {
                    if (Inventory.instance.inventoryItemList[i].itemCount >= 2)
                    {
                        Inventory.instance.UseAnItem(i);
                        Inventory.instance.UseAnItem(i);
                        canBuy = true;
                        break;
                    }
                    else if (Inventory.instance.inventoryItemList[i].itemCount == 1 && !isChecked3)
                    {
                        slots[slotIndex] = i;
                        slotIndex++;
                        totalCount--;
                        isChecked3 = true;
                    }
                }
            }
            if (totalCount == 0)
            {
                canBuy = true;

                for (int i = 0; i < slots.Length; i++)
                {
                    Inventory.instance.UseAnItem(slots[i]);
                }
            }
            if (!canBuy)
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "MatShortage_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
            else 
            {
                Inventory.instance.GetAnItem(itemCode);
                canBuy = false;
            }
        }
        else if (itemCode == 30002) //커피
        {
            PurchaseItem(itemCode, itemPrice);
        }
        else //그 외 음식
        {
            for (int i = 0; i < Inventory.instance.inventoryItemList.Count; i++) // 인벤토리에 같은 아이템이 있는지 검색
            {
                if (Inventory.instance.inventoryItemList[i].itemID == matCode1 && matCount1 != 0) //있을 경우
                {
                    if (Inventory.instance.inventoryItemList[i].itemCount >= matCount1)
                    {
                        matSlot1 = i;
                        totalCount -= matCount1;
                        matCount1 = 0;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (Inventory.instance.inventoryItemList[i].itemID == matCode2 && matCount2 != 0)
                {
                    if (Inventory.instance.inventoryItemList[i].itemCount >= matCount2)
                    {
                        matSlot2 = i;
                        totalCount -= matCount2;
                        matCount2 = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (matCount1 == 0 && matCount2 == 0)//조건충족
            {
                canBuy = true;
            }
            ResetVariables();
            if (!canBuy)
            {
                noticePanel.sprite = Resources.Load("Sprites/" + "MatShortage_Notice", typeof(Sprite)) as Sprite;
                noticePanel.gameObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < matCount1; i++)
                {
                    Inventory.instance.UseAnItem(matSlot1);
                }
                for (int i = 0; i < matCount2; i++)
                {
                    Inventory.instance.UseAnItem(matSlot2);
                }
                Inventory.instance.GetAnItem(itemCode);
                canBuy = false;
            }
        }
    }

    void ResetArray()
    {
        slotIndex = 0;
        slots = new int[] { 0 }; //배열 초기화하기.
    }

    void ResetVariables()
    {
        switch (itemCode)
        {
            case 30001:
                matCount1 = 0;
                matCount2 = 0;
                totalCount = 2;
                isChecked1 = false;
                isChecked2 = false;
                isChecked3 = false; 
                break;
            case 30002:
                break;
            case 30003:
                matCount1 = 2;
                matCount2 = 2;
                totalCount = 4;
                break;
            case 30004:
                matCount1 = 2;
                matCount2 = 0;
                totalCount = 2;
                break;
            case 30005:
                matCount1 = 1;
                matCount2 = 2;
                totalCount = 3;
                break;
        }
    }
}
