using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float dmg = 1f;

    public int AOE = 0;

    public GameObject target;
    public List<Enemy> AOETargets = new List<Enemy>();


    private void Start()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = AOE;
        //Debug.Log(this.gameObject.name + " Has collider sized: " + AOE);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) < 0.001f)
            {

                if (AOE > 0)
                {
                    float radius = AOE / 2;

                    ParticleSystem ps = gameObject.GetComponentInChildren<ParticleSystem>();
                    var sh = ps.shape;
                    sh.radius = radius;

                    gameObject.GetComponentInChildren<ParticleSystem>().Play();

                    if(AOETargets != null)
                    {
                        foreach (var Enemy in AOETargets)
                        {
                            if (Enemy)
                            {
                                Enemy.GetComponent<Enemy>().TakeHp(dmg);
                            }
                        }

                    }


                }

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

                if (AOE == 0)
                    target.GetComponent<Enemy>().TakeHp(Mathf.CeilToInt(dmg/2));

                target = null;
            }
        }

        else
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log(collision.gameObject.name);
            AOETargets.Add(collision.gameObject.GetComponent<Enemy>());
        }
    }

    

}
