using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy, enemyMother;

    void Awake()
    {
        instance = this;
    }
    
    public void SpawnEnemies()
    {
        GameObject e = Instantiate(enemy, TileManager.instance.tilePath[0].posReal, Quaternion.identity);
        e.transform.parent = enemyMother.transform;
    }
}
