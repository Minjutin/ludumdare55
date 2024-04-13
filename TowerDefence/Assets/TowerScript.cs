using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> enemies = new List<GameObject>();

    public float shootEveryInterval = 2.0f; 
    private float cooldownTimer = 0.0f;
    public float scanArea;

    void Start()
    {

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
            clone.GetComponent<BulletScript>().target = enemies[0];

            cooldownTimer = shootEveryInterval;
            Destroy(clone, 3f);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemies.Remove(collision.gameObject);
        }
    }


}
