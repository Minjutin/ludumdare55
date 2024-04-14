using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Resource things
    public GameObject resourceMother;
    public Sprite resBone, resMeat, resPlutonium, resPotion;
    public Dictionary<Resource.Type, int> resAmount = new();
    public GameObject resourceDropped;
    

    void Awake()
    {
        instance = this;
        resAmount.Add(Resource.Type.Meat, 5);
        resAmount.Add(Resource.Type.Bone, 5);
        resAmount.Add(Resource.Type.Potion, 5);
        resAmount.Add(Resource.Type.Plutonium, 5);

    }
    // Start is called before the first frame update
    void Start()
    {
        TileManager.instance.InitializeTiles();
        EnemyManager.instance.SpawnEnemies();
        MainCanvas.instance.UpdateText();
    }
}
