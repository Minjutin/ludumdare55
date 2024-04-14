using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> pickedResources;
    List<Resource.Type> picked;

    private void OnEnable()
    {
        foreach(GameObject i in pickedResources)
        {
            Debug.Log(i.transform.GetChild(0).gameObject.name);
            i.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
