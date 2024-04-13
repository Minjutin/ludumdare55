using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;
    public Sprite ranged, dmg, aoe, boost;
    public GameObject bulletMother;

    private void Awake()
    {
        instance = this;
    }
}
