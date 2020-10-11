using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject storeWindow;
    public void OnMouseUp()
    {
        storeWindow.SetActive(true);
        Database.instance.sellEnabled = true;
    }

    public void BtnOK()
    {
        Database.instance.sellEnabled = false;
        storeWindow.SetActive(false);
    }

}
