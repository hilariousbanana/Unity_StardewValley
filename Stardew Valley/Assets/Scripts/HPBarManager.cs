using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    public Slider hpBar;

    // Update is called once per frame
    void Update()
    {
        hpBar.value = Database.instance.curHp * 0.01f;
    }
}
