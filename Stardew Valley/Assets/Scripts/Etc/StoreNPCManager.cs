using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreNPCManager : MonoBehaviour
{
    public int storeNumber;
    public void OnMouseUp()
    {
        if (DataController.instance.data.storeActivated == false)
        {
            AudioManager.instance.Play("OpenWindow");
            DataController.instance.data.storeActivated = true;
            DataController.instance.data.storeNumber = storeNumber;
            DataController.instance.data.sellEnabled = true;
        }
    }
}
