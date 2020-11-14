using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public Text date_Text;
    public Text time_Text;
    public Text gold_Text;
    public Text colon;

    private void Start()
    {
        colon.text = ":";
        StartCoroutine(BlinkText());
    }
    // Update is called once per frame
    void Update()
    {
        date_Text.text = DataController.instance.data.season_Text + " " + DataController.instance.data.day_Text;
        time_Text.text = DataController.instance.data.hour_Text + " " + DataController.instance.data.minute_Text;
        gold_Text.text = DataController.instance.data.gold_Text;
    }

    IEnumerator BlinkText()
    {
        while(true)
        {
            colon.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            colon.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
