using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI resources;


    // Update is called once per frame
    void Update()
    {
        resources.text = "Meat: " + GameManager.instance.meats + "\r\nBones: " + GameManager.instance.bones + "\r\nPotions: " + GameManager.instance.potions + "\r\nPlutonium: " + GameManager.instance.plutoniums;
    }
}
