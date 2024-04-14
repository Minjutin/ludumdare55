using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float dmg = 1f;
    public GameObject target;
    public bool isAOE;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.001f)
            {
                if (isAOE)
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                
                target.GetComponent<Enemy>().TakeHp(dmg);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);

            }
        }
        else
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        
    }
}
