using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject storeWindow;
    public void OnMouseUp()
    {
        if(DataController.instance.data.storeActivated == false)
        {
            AudioManager.instance.Play("OpenWindow");
            DataController.instance.data.storeActivated = true;
            storeWindow.SetActive(true);
            DataController.instance.data.sellEnabled = true;
        }
    }

    public void BtnOK()
    {
        AudioManager.instance.Play("OpenWindow");
        DataController.instance.data.sellEnabled = false;
        DataController.instance.data.storeActivated = false;
        storeWindow.SetActive(false);
    }

}
