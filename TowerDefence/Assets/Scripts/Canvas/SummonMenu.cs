using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SummonMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> pickedResources = new();
    [SerializeField] TMPro.TextMeshProUGUI bones, meats, plutoniums, potions;
    List<Resource.Type> picked = new();
    public TowerScript cTower;

    private void OnEnable()
    {
        UpdateTexts();

        picked.Clear();

        foreach (GameObject i in pickedResources)
        {
            //Debug.Log(i.transform.GetChild(0).gameObject.name);
            i.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
    }

    void UpdateTexts()
    {
        bones.text = GameManager.instance.resAmount[Resource.Type.Bone] + "";
        meats.text = GameManager.instance.resAmount[Resource.Type.Meat] + "";
        plutoniums.text = GameManager.instance.resAmount[Resource.Type.Plutonium] + "";
        potions.text = GameManager.instance.resAmount[Resource.Type.Potion] + "";
    }

    public void AddResource(string type)
    {
        if(picked.Count < 10)
        {
            Resource.Type t1 = Resource.Type.Plutonium;
            switch (type.ToLower())
            {

                case "bone":
                    t1 = Resource.Type.Bone;
                    if (GameManager.instance.resAmount[t1] < 1)
                    {
                        return;
                    }
                    picked.Add(t1);


                    pickedResources[picked.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GameManager.instance.resBone;
                    
                    break;
                case "meat":
                    t1=Resource.Type.Meat;
                    if (GameManager.instance.resAmount[t1] < 1)
                    {
                        return;
                    }
                    picked.Add(t1);

                    pickedResources[picked.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GameManager.instance.resMeat;
                    
                    break;
                case "plutonium":
                    t1=Resource.Type.Plutonium;
                    if (GameManager.instance.resAmount[t1] < 1)
                    {
                        return;
                    }
                    picked.Add(t1);
                    pickedResources[picked.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GameManager.instance.resPlutonium;
                    
                    break;
                case "potion":
                    t1=Resource.Type.Potion;
                    if (GameManager.instance.resAmount[t1] < 1)
                    {
                        return;
                    }
                    picked.Add(t1);
                    pickedResources[picked.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GameManager.instance.resPotion;                  
                    break;
                default:
                    Debug.Log("wtf man");
                    break;

            }
            GameManager.instance.resAmount[t1]--;
            pickedResources[picked.Count - 1].transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            UpdateTexts();
        }
        MainCanvas.instance.UpdateText();
    }


    public void CreateTower()
    {
        cTower.InitTower(picked.Where(x => x == Resource.Type.Meat).ToList().Count, picked.Where(x=>x==Resource.Type.Bone).ToList().Count, picked.Where(x => x == Resource.Type.Potion).ToList().Count, picked.Where(x => x == Resource.Type.Plutonium).ToList().Count);
        gameObject.SetActive(false);
    }
}
