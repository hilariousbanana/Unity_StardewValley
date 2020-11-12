using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject storeWindow;
    public void OnMouseUp()
    {
        if(Database.instance.storeActivated == false)
        {
            AudioManager.instance.Play("OpenWindow");
            Database.instance.storeActivated = true;
            storeWindow.SetActive(true);
            Database.instance.sellEnabled = true;
        }
    }

    public void BtnOK()
    {
        AudioManager.instance.Play("OpenWindow");
        Database.instance.sellEnabled = false;
        Database.instance.storeActivated = false;
        storeWindow.SetActive(false);
    }

}
