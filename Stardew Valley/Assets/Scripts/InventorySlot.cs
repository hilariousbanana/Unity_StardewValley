using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public GameObject chosenBox;
    public Text itemCount_Text;
    public Text slotNumber_Text;
    public Transform pos;
    public bool usable = false;
    public int slotNumber;
    private int clickedTimes = 0;


    public void Clicked()
    {
        //Database.instance.chosenSlot = slotNumber;
        usable = true;
        chosenBox.transform.SetParent(pos.gameObject.transform);
        chosenBox.transform.position = pos.position;

        Debug.Log("Clicked. at" + slotNumber);
    }

    private void Update()
    {
        slotNumber_Text.text = slotNumber.ToString();
    }

    public void AddItem(Item _item)
    {
        icon.sprite = _item.itemIcon;

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
    }

}
