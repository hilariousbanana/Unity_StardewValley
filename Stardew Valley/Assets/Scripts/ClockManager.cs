using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public Text date_Text;
    public Text time_Text;
    public Text gold_Text;

    private Database db;
    // Start is called before the first frame update
    void Start()
    {
        db = FindObjectOfType<Database>();
    }

    // Update is called once per frame
    void Update()
    {
        date_Text.text = db.season_Text + " " +db.day_Text;
        time_Text.text = db.hour_Text + ":" + db.minute_Text;
        gold_Text.text = db.gold_Text;
    }
}
