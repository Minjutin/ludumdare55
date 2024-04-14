using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Sprite empty, ranged, dmg, aoe, boost;

    public GameObject bulletMother, towerMother;

    public GameObject defTower;

    float t = 0;
    [SerializeField] float timeCount;

    private void Awake()
    {
        instance = this;
        t = timeCount;
    }

    private void Update()
    {
        SpawnTower();
    }

    private void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
    }

    public void SpawnTower()
    {
        TileStatus willSpawn = TileManager.instance.GetEmptyTile();
        if (willSpawn != null && t>timeCount)
        {
            GameObject tow = Instantiate(defTower, willSpawn.posReal, Quaternion.identity);
            tow.transform.parent = towerMother.transform;
            tow.GetComponent<TowerScript>().tile = willSpawn;
            //tow.GetComponent<TowerScript>().InitTower(2,4,5,6);
            willSpawn.isEmpty = false;
            t = 0;
        }

    }
}
