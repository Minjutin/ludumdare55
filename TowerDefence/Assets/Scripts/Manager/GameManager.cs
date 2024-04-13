using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Resource things
    public GameObject resourceMother;
    public Sprite resBone, resMeat, resPlutonium, resPotion;
    public int bones, meats, plutoniums, potions;
    

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        TileManager.instance.InitializeTiles();
        EnemyManager.instance.SpawnEnemies();
    }
}
