using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferManager : MonoBehaviour
{
    private GameObject player;
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
        player = FindObjectOfType<MovingObject>().gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            StartCoroutine(MoveCoroutine());
            Database.instance.curMapNum = mapNumber;
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
