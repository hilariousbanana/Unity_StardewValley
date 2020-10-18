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
    public TMP_Text itemCount_Text;
    public Transform pos;
    public bool usable = false;
    public int slotNumber;
    private int clickedTimes = 0;


    public void Clicked()
    {
        clickedTimes++;
        if (usable == false) //처음 클릭 한 경우
        {
            clickedTimes = 1;
            Database.instance.chosenSlot = slotNumber;
            usable = true;
            //chosenBox.transform.SetParent(pos.gameObject.transform);
            //chosenBox.transform.localPosition = pos.localPosition;
        }
        if(usable == true && clickedTimes >=2)
        {
            usable = false;
        }
        Debug.Log("Clicked. at" + slotNumber);
    }

    private void Update()
    {
        
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
