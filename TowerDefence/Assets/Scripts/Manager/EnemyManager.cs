using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy, enemyMother;

    float t = 0; 
    [SerializeField] float enemySpawnTime;

    public Sprite meatE, boneE, potionE, plutoniumE;

    void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        if (t > enemySpawnTime)
        {
            t = 0;
            GameObject e = Instantiate(enemy, TileManager.instance.tilePath[0].posReal, Quaternion.identity);
            e.transform.parent = enemyMother.transform;
        }

    }
}
