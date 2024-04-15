using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource meatball;
    public AudioSource skeleton;
    public AudioSource plutonium;

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


}
