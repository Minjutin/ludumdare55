using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> enemies = new List<GameObject>();
    public List<TowerScript> towers = new();

    public TileStatus tile;

    public bool isInited = false;

    int dmg, range, aoe, boost; //ints

    public TMPro.TextMeshPro txt;

    public float shootEveryInterval = 2.0f; 
    private float cooldownTimer = 0.0f;

    public void InitTower(int _dmg, int _range, int _aoe, int _boost)
    {
        dmg = _dmg; range = _range; aoe = _aoe; boost = _boost;
        GetComponent<CircleCollider2D>().radius = range/1.5f;

        if(dmg == 0 && range == 0 && aoe == 0 && boost == 0)
        {
            tile.isEmpty = true;
            Destroy(this.gameObject);
        }

        //SET SPRITEz
        if (dmg>range && dmg > aoe && dmg>boost)
            GetComponent<SpriteRenderer>().sprite = TowerManager.instance.dmg;
        else if (range>aoe && range > boost)
           GetComponent<SpriteRenderer>().sprite = TowerManager.instance.ranged;
        else if (aoe > boost)
            GetComponent<SpriteRenderer>().sprite = TowerManager.instance.aoe;
        else
            GetComponent<SpriteRenderer>().sprite = TowerManager.instance.boost;

        if (boost > 0)
            gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        

        isInited = true;
        range++;

        txt.gameObject.SetActive(true);
        txt.text = "dmg "+dmg+"   rge "+range+"\r\naoe " +aoe+"   bst "+boost;
    }

    //Give boost to towers around it
    private void FixedUpdate()
    {
        cooldownTimer -= Time.fixedDeltaTime;

        if (cooldownTimer <= 0)
            Shoot();

        //Check boost
        if (boost > 0)
        {
            foreach(TowerScript i in towers)
            {
                i.cooldownTimer -= Time.fixedDeltaTime*(boost/2);
            }
        }
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
            clone.GetComponent<BulletScript>().dmg = dmg+1;

            if(aoe > 0)
                clone.GetComponent<BulletScript>().AOE = aoe;

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
        if (collision.gameObject.GetComponent<TowerScript>())
        {
            towers.Add(collision.gameObject.GetComponent<TowerScript>());
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
