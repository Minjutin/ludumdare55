using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float dmg = 1f;

    public bool isAOE;

    public GameObject target;
    public List<Enemy> AOETargets = new List<Enemy>();


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
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();

                    if(AOETargets != null)
                        foreach (var Enemy in AOETargets)
                            Enemy.GetComponent<Enemy>().TakeHp(dmg);

                }

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                target.GetComponent<Enemy>().TakeHp(dmg);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);

            }
        }

        else
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name);
            AOETargets.Add(collision.gameObject.GetComponent<Enemy>());
        }
    }

    

}
