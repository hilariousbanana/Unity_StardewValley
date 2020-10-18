using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Transform[] posArray;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = posArray[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0, 0, 0);
        this.transform.position = posArray[Database.instance.chosenSlot].position;
    }
}
