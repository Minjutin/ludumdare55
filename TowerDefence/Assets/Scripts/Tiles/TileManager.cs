using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    public TileArray groundTiles, indicatorTiles; //All tile arrays

    //IMPORTANT! All tiles in one array.
    public Dictionary<Vector2, TileStatus> tiles = new();
    public List<TileStatus> tilePath = new();

    public GameObject test;

    //When the tile manager appears, do initializing
    private void Awake()
    {
        instance = this;
    }



    //Initialize things
    public void InitializeTiles()
    {
        //Initialize arrays
        groundTiles.InitializeArray();
        indicatorTiles.InitializeArray();

        //Initialize local tile array that is used in the game
        CreateTiles();
        CreatePath();

        Debug.Log(tilePath.Count);

        //foreach(TileStatus i in tilePath)
        //{
        //    Instantiate(test, i.posReal, Quaternion.identity);
        //}
         
    }

    // -------------------  Actually create the tiles used
    private void CreateTiles()
    {
        //Go through the arrays and add important informations to the tiledata
        for (int x = 0; x < TileArray.bounds.size.x; x++)
        {
            for (int y = 0; y < TileArray.bounds.size.y; y++)
            {
                //Get data of the tile
                TileStatus tile = new();
                tiles.Add(new Vector2(x, y), tile);
                //Update the physical location of the tile
                tile.posReal = groundTiles.tiles[x, y].location;
                tile.posInArray = new Vector2Int(x, y);

                SetUpTile(tile);
            }
        }

        indicatorTiles.gameObject.SetActive(false); //Set icon layers unactive
    }

    public void SetUpTile(TileStatus tile)
    {
        int x = tile.posInArray.x;
        int y = tile.posInArray.y;

        //-----------------------------------------
        //If there is floor, update
        if (groundTiles.tiles[x, y].tileType && groundTiles.tiles[x, y].tileType.name.ToLower().Contains("path"))
        {
            tile.isPath = true;
        }
        if(indicatorTiles.tiles[x, y].tileType && indicatorTiles.tiles[x, y].tileType.name.ToLower().Contains("start"))
        {
            tile.isFirst = true;
        }
        if (indicatorTiles.tiles[x, y].tileType && indicatorTiles.tiles[x, y].tileType.name.ToLower().Contains("finish"))
        {
            tile.isLast = true;
        }

        //-----------------------------------------
    }

    //-------------------------------
    //CHECKING TILES help------------
    //-------------------------------

    #region Fetch and use tiles
    //Get tile from a location. If there is no tile, return null.
    public TileStatus GetTile(Vector2 location)
    {
        if (tiles.ContainsKey(location))
        {
            return tiles[location];
        }
        else
        {
            return null;
        }
    }


    public void CreatePath()
    {

        //Create a path
        foreach (TileStatus i in tiles.Values)
        {
            if (i.isFirst)
            {
                tilePath.Add(i);
            }
        }

        if (tilePath.Count < 1)
        {
            Debug.Log("No start point");
        }

        int counter = 0;

        //Loop till we find the last tile
        while (true)
        {
            TileStatus currentTile = tilePath[tilePath.Count - 1];
            TileStatus nextTile = null;
            TileStatus previousTile = currentTile;

            //Get previous tile
            if (tilePath.Count > 1) { 
                previousTile = tilePath[tilePath.Count - 2];
            }

            Vector2Int[] aroundTiles = { currentTile.posInArray + new Vector2Int(1, 0), currentTile.posInArray + new Vector2Int(-1, 0), currentTile.posInArray + new Vector2Int(0, 1), currentTile.posInArray + new Vector2Int(0, -1) };

            foreach (Vector2Int i in aroundTiles)
            {
          
                if (tiles.ContainsKey(i) && i != previousTile.posInArray && tiles[i].isPath)
                {
                    tilePath.Add(tiles[i]);
                    break;
                }
            }


            if (nextTile != null)
            {
                if (nextTile.isLast)
                {
                    break;
                }
            }

            counter++;
            if(counter > 100)
            {
                break;
            }
        }
    }

    //Ädd tile to a list if it can be found. If not, skip it
    public void AddTileToList(List<TileStatus> tileList, Vector2 location)
    {
        if (GetTile(location) != null)
        {
            tileList.Add(GetTile(location));
        }
    }
    #endregion
}
