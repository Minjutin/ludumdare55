using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> pickedResources;
    [SerializeField] TMPro.TextMeshProUGUI bones, meats, plutoniums, potions;
    List<Resource.Type> picked;

    private void OnEnable()
    {
        bones.text = GameManager.instance.resAmount[Resource.Type.Bone]+"";
        meats.text = GameManager.instance.resAmount[Resource.Type.Meat] + "";
        plutoniums.text = GameManager.instance.resAmount[Resource.Type.Plutonium] + "";
        potions.text = GameManager.instance.resAmount[Resource.Type.Potion] + "";

        foreach (GameObject i in pickedResources)
        {
            Debug.Log(i.transform.GetChild(0).gameObject.name);
            i.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
}
