using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> enemies = new List<GameObject>();

    public bool isInited = false;

    int dmg, range, aoe, boost; //ints

    public float shootEveryInterval = 2.0f; 
    private float cooldownTimer = 0.0f;

    public void InitTower(int _dmg, int _range, int _aoe, int _boost)
    {
        dmg = _dmg; range = _range; aoe = _aoe; boost = _boost;
        GetComponent<CircleCollider2D>().radius = range/2;
        isInited = true;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
            Shoot();

    }

    void Shoot()
    {
        if (enemies.Count <= 0) 
            return;
        else
        {
            GameObject clone;
            clone = Instantiate(prefab, transform.position, transform.rotation);
            clone.transform.parent = TowerManager.instance.bulletMother.transform;
            clone.GetComponent<BulletScript>().target = enemies[0];
            clone.GetComponent<BulletScript>().dmg = dmg;

            cooldownTimer = shootEveryInterval;
            Destroy(clone, 3f);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }


}
