using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepManager : MonoBehaviour
{
    public Image noticePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            noticePanel.sprite = Resources.Load("Sprites/" + "Sleep_Notice", typeof(Sprite)) as Sprite;
            noticePanel.gameObject.SetActive(true);
        }
    }
}
