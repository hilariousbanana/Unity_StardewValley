using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DataController.instance.data.level = level;
    }

    public void PrintLevel()
    {
        Debug.Log(DataController.instance.data.level);
    }
}
