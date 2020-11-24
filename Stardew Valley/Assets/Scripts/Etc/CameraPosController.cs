using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosController : MonoBehaviour
{
    public Transform[] camPos;

    private void Start()
    {
        this.transform.position = camPos[DataController.instance.data.curMapNum].position;
    }
}
