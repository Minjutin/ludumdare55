using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public TMPro.TextMeshProUGUI resources, level;

    public GameObject SummonMenu, winMenu;

    private void Awake()
    {
        instance = this;
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

    public void UpdateLevel(string txt)
    {
        level.text = "Level " + txt;
    }

    public void OpenWinCanvas()
    {
        winMenu.SetActive(true);
    }
}
