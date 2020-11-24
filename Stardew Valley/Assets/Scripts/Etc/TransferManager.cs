using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferManager : MonoBehaviour
{
    private GameObject player;
    //public GameObject canvas;
    public GameObject panel; 
    public Transform targetPos;
    private Camera cam;
    public Transform camPos;
    private BoxCollider2D boxCollider;
    public int mapNumber;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //canvas = GameObject.Find("Canvas");
        //panel = canvas.transform.GetChild(4).gameObject;
        player = FindObjectOfType<MovingObject>().gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if(collider.gameObject.tag == "Player")
    //    {
    //        panel.SetActive(true);
    //        StartCoroutine(MoveCoroutine());
    //        Database.instance.curMapNum = mapNumber;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            StartCoroutine(MoveCoroutine());
            DataController.instance.data.curMapNum = mapNumber;
        }
    }

    IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.position = targetPos.position;
        cam.transform.position = camPos.position;
        yield return null;
    }
}
