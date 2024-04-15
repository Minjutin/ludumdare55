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

    public bool infinite = false;

    [Header("FPS Warning")]
    private int fps;
    public bool shownFPSWarning; //very serious, needs its own bool
    public GameObject WarningCanvas;

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

    private void Update()
    {
        if(!shownFPSWarning)
            InvokeRepeating("checkFPS", 2.0f, 2.0f);

        fps = ((int)(1f / Time.unscaledDeltaTime));
    }

    public void NextLevel()
    {
        if (currentLevel < 10 || infinite)
        {
            currentLevel++;
            MainCanvas.instance.UpdateLevel(currentLevel);
            EnemyManager.instance.enemyHp = currentLevel * currentLevel;

            if(EnemyManager.instance.enemySpawnTime > 0.3f)
            {
                EnemyManager.instance.enemySpawnTime -= 0.2f;
            }
            else
            {
                EnemyManager.instance.enemySpawnTime = 0.1f;
            }


        }
        else
        {
            MainCanvas.instance.winMenu.SetActive(true);
            Time.timeScale = 0;
        }
      
    }

    public void AddResource(Resource.Type type)
    {
        resAmount[type]++;
        MainCanvas.instance.UpdateText();
    }

    public void checkFPS()
    {
        if (fps < 20)
            WarningCanvas.SetActive(true);
    }
}
