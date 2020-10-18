using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmEntered : MonoBehaviour
{
    public bool control;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Database.instance.inFarm = control;
        }
    }
}
