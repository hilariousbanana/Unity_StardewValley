using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeManager : MonoBehaviour
{
    public GameObject panel;
    public void BtnOk()
    {
        panel.SetActive(false);
    }
}
