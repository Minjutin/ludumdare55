using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Sprite empty, ranged, dmg, aoe, boost;

    public GameObject bulletMother, towerMother;

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
            GameObject tow = Instantiate(defTower, willSpawn.posReal, Quaternion.identity);
            tow.transform.parent = towerMother.transform;
            //tow.GetComponent<TowerScript>().InitTower(2,4,5,6);
            willSpawn.isEmpty = false;
        }

    }
}
