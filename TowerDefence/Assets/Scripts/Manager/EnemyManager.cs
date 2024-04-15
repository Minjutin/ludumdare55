using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy, enemyMother;

    public int enemyHp = 1;

    float t = 0; 
    public float enemySpawnTime = 2;

    public Sprite meatE, boneE, potionE, plutoniumE;

    public float boneprob, meatprob, plutprob, potprob;

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
            GameObject e = Instantiate(enemy, new Vector2(-20,0.6f), Quaternion.identity);
            e.transform.parent = enemyMother.transform;
            e.GetComponent<Enemy>().hp = enemyHp;
        }

    }
}
