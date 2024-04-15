using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioHandler : MonoBehaviour
{

    private void OnDestroy()
    {
        int rnd = Random.Range(1, 20);
        string name = gameObject.GetComponent<Enemy>().type.ToString();

        //Debug.Log("Rolled: " + rnd);

        if (GameManager.instance)
        {
            if (rnd > 15)
            {
                switch (name)
                {
                    case "Bone":
                        if (!GameManager.instance.GetComponent<AudioManager>().skeleton.isPlaying)
                            GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("skeleton");
                        break;
                    case "Meat":
                        if (!GameManager.instance.GetComponent<AudioManager>().meatball.isPlaying)
                            GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("meatball");
                        break;
                    case "Plutonium":
                        if (!GameManager.instance.GetComponent<AudioManager>().plutonium.isPlaying)
                            GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("plutonium");
                        break;
                    default:
                        break;
                }
            }


        }
    }
}
