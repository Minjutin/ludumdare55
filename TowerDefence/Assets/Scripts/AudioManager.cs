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


}
