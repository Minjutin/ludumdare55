using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public static MainCanvas instance;
    public TMPro.TextMeshProUGUI resources;

    public GameObject SummonMenu;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void UpdateText()
    {
        resources.text = "Meat: " + GameManager.instance.resAmount[Resource.Type.Meat] + "\r\nBones: " + GameManager.instance.resAmount[Resource.Type.Bone] + "\r\nPotions: " + GameManager.instance.resAmount[Resource.Type.Potion] + "\r\nPlutonium: " + GameManager.instance.resAmount[Resource.Type.Plutonium];
    }

    public void StartSummoning(TowerScript tower)
    {
        SummonMenu.SetActive(true);
    }
}
