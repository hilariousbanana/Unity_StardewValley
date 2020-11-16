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
        AudioManager.instance.Play("Click");
        if (panel.sprite.name == "Sleep_Notice" || panel.sprite.name == "DayEnded_Notice") //잠들경우
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            BGMManager.instance.FadeOut();
            DataController.instance.data.sleepHour = DataController.instance.data.hour;
            DataController.instance.data.isSleeping = true;
        }
        else if (panel.sprite.name == "GameOver_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            DataController.instance.data.reset = true;
        }
        else
            Time.timeScale = 1;
        panel.sprite = null;
        DataController.instance.data.noticeActivated = false;
        panel.gameObject.SetActive(false);
    }

    public void BtnNo()
    {
        AudioManager.instance.Play("Click");
        if (panel.sprite.name == "GameOver_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            DataController.instance.data.reset = true;
        }
        else if (panel.sprite.name == "DayEnded_Notice")
        {
            Time.timeScale = 0;
            fadePanel.SetActive(true);
            Time.timeScale = 1;
            DataController.instance.data.sleepHour = DataController.instance.data.hour;
            DataController.instance.data.isSleeping = true;
        }
        else
            Time.timeScale = 1;
        panel.sprite = null;
        DataController.instance.data.noticeActivated = false;
        panel.gameObject.SetActive(false);
    }
}
