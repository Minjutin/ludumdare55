using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum Type { Meat, Bone, Potion, Plutonium };
    Type type;

    public void InitThis(Type resource)
    {
        type = resource;
        switch (type)
        {
            case Resource.Type.Meat:
                transform.GetComponent<SpriteRenderer>().sprite = GameManager.instance.resMeat;
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resMeat;
                break;
            case Resource.Type.Bone:
                transform.GetComponent<SpriteRenderer>().sprite = GameManager.instance.resBone;
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resBone;
                break;
            case Resource.Type.Potion:
                transform.GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPotion;
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPotion;
                break;
            case Resource.Type.Plutonium:
                transform.GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPlutonium;
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPlutonium;
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        Destroy(gameObject, 8f);
    }

    public void Collect()
    {
        GameManager.instance.AddResource(type);
        Destroy(gameObject);
    }

}
