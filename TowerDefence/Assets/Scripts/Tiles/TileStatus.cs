using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStatus
{
    public bool isPath = false; //Is there floor
    public bool isFirst = false;
    public bool isLast = false;

    public Vector3 posReal;//The irl position of the tile to help finding positions for gameobjects

    public Vector2Int posInArray;//Needed to find out what tiles are next to it
}
