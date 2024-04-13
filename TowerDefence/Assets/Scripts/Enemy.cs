using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float hp;
    TileStatus currentTile, nextTile;
    int pathIndicator = 0;
    float t = 0;
    float moveTime = 1f;

    private void Start()
    {
        currentTile = TileManager.instance.tilePath[pathIndicator];
        nextTile = TileManager.instance.tilePath[pathIndicator+1];
    }

    private void FixedUpdate()
    {

        if (t > 0.99f)
        {
            t = 0;
            pathIndicator++;
            currentTile = nextTile;

            if (currentTile.isLast)
            {
                Destroy(gameObject);
            }
            else
            {
                nextTile = TileManager.instance.tilePath[pathIndicator + 1];
            }
        }

        MoveEnemy();
    }

    public void MoveEnemy()
    {
        this.transform.position = Vector2.Lerp(currentTile.posReal, nextTile.posReal, t);
        t += Time.fixedDeltaTime/moveTime;
    }
}
