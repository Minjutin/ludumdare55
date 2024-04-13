using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            //Destroy everything?

        }
    }
}
