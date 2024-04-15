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

    public int currentLevel = 1;
    

    void Awake()
    {
        instance = this;
        resAmount.Add(Resource.Type.Meat, 1);
        resAmount.Add(Resource.Type.Bone, 1);
        resAmount.Add(Resource.Type.Potion, 1);
        resAmount.Add(Resource.Type.Plutonium, 1);

    }
    // Start is called before the first frame update
    void Start()
    {
        TileManager.instance.InitializeTiles();
        EnemyManager.instance.SpawnEnemies();
        MainCanvas.instance.UpdateText();

        EnemyManager.instance.enemyHp = 1;
    }

    public void NextLevel()
    {
        if (currentLevel < 10)
        {
            currentLevel++;
            MainCanvas.instance.UpdateLevel(currentLevel);
            EnemyManager.instance.enemyHp = currentLevel * currentLevel;
            EnemyManager.instance.enemySpawnTime -= - 0.2f;
        }
        else
        {
            MainCanvas.instance.winMenu.SetActive(true);
            Time.timeScale = 0;
        }
      
    }

}
