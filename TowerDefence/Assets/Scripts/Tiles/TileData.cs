using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData
{
    public TileBase tileType;
    public Vector3 location;

    public TileData(TileBase tileb, Vector2 loc)
    {
        tileType = tileb;
        location = loc;
    }
}
