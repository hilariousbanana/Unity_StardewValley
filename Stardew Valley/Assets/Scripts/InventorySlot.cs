using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemCount_Text;

    public void AddItem(Item _item)
    { 
        icon.sprite = _item.itemIcon;

        if (_item.itemCount > 0)
        {
            itemCount_Text.text = _item.itemCount.ToString();
        }
        else
            itemCount_Text.text = "";
    }

    public void RemoveItem()
    {
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
