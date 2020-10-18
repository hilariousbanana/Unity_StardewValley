using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoxMaanger : MonoBehaviour
{
    public GameObject tiles;
    // Update is called once per frame
    void Update()
    {
        if (Database.instance.inFarm == true)
        {
            tiles.SetActive(true);
        }
        else
            tiles.SetActive(false);
    }
}
