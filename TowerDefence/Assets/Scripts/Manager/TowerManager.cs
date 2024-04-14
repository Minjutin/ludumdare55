using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Sprite empty, ranged, dmg, aoe, boost;

    public GameObject bulletMother;

    public GameObject defTower;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        SpawnTower();
    }

    public void SpawnTower()
    {
        TileStatus willSpawn = TileManager.instance.GetEmptyTile();
        if (willSpawn != null)
        {
            Instantiate(defTower, willSpawn.posReal, Quaternion.identity);
            willSpawn.isEmpty = false;
        }

    }
}
