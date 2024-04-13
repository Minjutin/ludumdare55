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
        switch (resource)
        {
            case Resource.Type.Meat:
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resMeat;
                break;
            case Resource.Type.Bone:
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resBone;
                break;
            case Resource.Type.Potion:
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPotion;
                break;
            case Resource.Type.Plutonium:
                GetComponent<SpriteRenderer>().sprite = GameManager.instance.resPlutonium;
                break;
            default:
                break;
        }
    }
}
