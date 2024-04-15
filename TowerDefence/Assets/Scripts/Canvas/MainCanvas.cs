using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public TMPro.TextMeshProUGUI resources, level;

    public GameObject SummonMenu, winMenu, tutorial;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OpenTutorial(true);
    }

    // Update is called once per frame
    public void UpdateText()
    {
        resources.text = GameManager.instance.resAmount[Resource.Type.Meat] + "\r\n" + GameManager.instance.resAmount[Resource.Type.Bone] + "\r\n" + GameManager.instance.resAmount[Resource.Type.Potion] + "\r\n" + GameManager.instance.resAmount[Resource.Type.Plutonium];
    }

    public void StartSummoning(TowerScript tower)
    {
        SummonMenu.GetComponent<SummonMenu>().cTower = tower;
        SummonMenu.SetActive(true);
    }

    public void UpdateLevel(int txt)
    {
        level.text = "Level " + txt;
    }

    public void OpenWinCanvas()
    {
        winMenu.SetActive(true);
    }

    public void OpenTutorial(bool opened)
    {
        tutorial.SetActive(opened);
        if (opened)
        {
            Time.timeScale = 0f;
        }
        else
            Time.timeScale = 1f;
    }
}
