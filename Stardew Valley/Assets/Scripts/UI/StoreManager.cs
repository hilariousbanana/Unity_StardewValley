using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject seedStore;
    public GameObject foodStore;

    private void Update()
    {
        if(DataController.instance.data.storeActivated)
        {
            switch(DataController.instance.data.storeNumber)
            {
                case 0:
                    seedStore.SetActive(true);
                    break;
                case 1:
                    foodStore.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void BtnOK()
    {
        AudioManager.instance.Play("OpenWindow");
        DataController.instance.data.sellEnabled = false;
        DataController.instance.data.storeActivated = false;
        switch (DataController.instance.data.storeNumber)
        {
            case 0:
                seedStore.SetActive(false);
                break;
            case 1:
                foodStore.SetActive(false);
                break;
            default:
                break;
        }
    }

}
