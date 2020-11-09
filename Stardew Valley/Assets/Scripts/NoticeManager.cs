using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeManager : MonoBehaviour
{
    public Image panel;
    public GameObject fadePanel;


    private void Update()
    {
 
    }

    public void BtnOk()
    {
        if (panel.sprite.name == "Sleep_Notice" || panel.sprite.name == "DayEnded_Notice") //잠들경우
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            Database.instance.sleepHour = Database.instance.hour;
            Database.instance.isSleeping = true;
        }
        else if (panel.sprite.name == "GameOver_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            Database.instance.reset = true;
        }
        else
            Time.timeScale = 1;
        panel.sprite = null;
        Database.instance.noticeActivated = false;
        panel.gameObject.SetActive(false);
    }

    public void BtnNo()
    {
        if (panel.sprite.name == "GameOver_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            Database.instance.reset = true;
        }
        else if (panel.sprite.name == "DayEnded_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            Database.instance.sleepHour = Database.instance.hour;
            Database.instance.isSleeping = true;
        }
        else
            Time.timeScale = 1;
        panel.sprite = null;
        Database.instance.noticeActivated = false;
        panel.gameObject.SetActive(false);
    }
}
