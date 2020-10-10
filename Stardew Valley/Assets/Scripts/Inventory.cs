
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
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
        inventoryItemList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();
    }

    
    private void Update()
    {
        if(!stopKeyInput)
        {
            
        }
    }
}
