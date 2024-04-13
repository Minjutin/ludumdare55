using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileArray : MonoBehaviour
{
    [SerializeField] bool isMain = false; //If it is main, the boundaries will be taken from it. 
    public TileData[,] tiles;
    public static BoundsInt bounds;

    private void Awake()
    {
        if (isMain)
        {
            bounds = GetComponent<Tilemap>().cellBounds;
        }
    }

    public void InitializeArray()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        TileBase[] tiles1d = tilemap.GetTilesBlock(bounds);
        tiles = new TileData[bounds.size.x, bounds.size.y]; //New Tilebase with certain length

        //Go through tiles1d and assign them to tiles 2d array as tiledatas.
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = bounds.size.y - 1; y >= 0; y--)
            {
                tiles[x, y] = new TileData(tiles1d[x + y * bounds.size.x], new Vector3(bounds.xMin + x + 0.5f, bounds.yMin + y + 0.5f, 0));
                //Debug.Log(gameObject.name + "," + x + ", " + y);
            }
        }

    }
}