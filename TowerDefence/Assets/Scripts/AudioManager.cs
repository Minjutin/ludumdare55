using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Deaths")]
    public AudioSource meatball;
    public AudioSource skeleton;
    public AudioSource plutonium;

    [Header("Interactions")]
    public AudioSource Click;

    [Header("Tower Attacks")]
    public AudioSource Attack1;
    public AudioSource Attack2;

    public void PlayDeathAudio(string Type)
    {
        switch (Type)
        {
            case "skeleton":
                skeleton.Play();
                break;
            case "meatball":
                meatball.Play();
                break;
            case "plutonium":
                plutonium.Play();
                break;

            default:
                break;
        }
    }

    public void InteractAudio()
    {
        Click.Play();
    }

    public void TowerShoot()
    {
        if(Random.Range(0,30) > 25) {
           int rand = Random.Range(0, 1);

            switch (rand)
            {
                case 0:
                    Attack1.Play();
                    break;
                case 1:
                    Attack2.Play();
                    break;
                default:
                    break;
            }
        }
    }

}
