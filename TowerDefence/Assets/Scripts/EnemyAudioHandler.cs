using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioHandler : MonoBehaviour
{

    private void OnDestroy()
    {
        int rnd = Random.Range(1, 20);
        string name = gameObject.GetComponent<Enemy>().type.ToString();

        if(rnd/2 == 0) {
            switch (name)
            {
                case "Bone":
                    GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("skeleton");
                    break;
                case "Meat":
                    GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("meatball");
                    break;
                case "Plutonium":
                    GameManager.instance.GetComponent<AudioManager>().PlayDeathAudio("plutonium");
                    break;
                default:
                    break;
            }

        }
    }
}
