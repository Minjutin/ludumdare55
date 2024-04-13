using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy;

    void Awake()
    {
        instance = this;
    }
    
    public void SpawnEnemies()
    {
        Instantiate(enemy, TileManager.instance.tilePath[0].posReal, Quaternion.identity);
    }
}
