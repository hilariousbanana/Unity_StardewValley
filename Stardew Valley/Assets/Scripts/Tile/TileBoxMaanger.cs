using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileBoxMaanger : MonoBehaviour
{
    public GameObject contents;
    private TileManager[] tiles;
    public Transform tf;

    private void Start()
    {
        tiles = tf.GetComponentsInChildren<TileManager>();

        for(int i = 0; i <tiles.Length; i++)
        {
            tiles[i].tileNumber = i;
        }
    }
}
