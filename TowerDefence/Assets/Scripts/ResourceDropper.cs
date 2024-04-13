using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDropper : MonoBehaviour
{
    [SerializeField] float maxTimer = 1;
    [SerializeField] int amount = 2;
    [SerializeField] float distance = 2;

    float timer = 0;
    [SerializeField] ResourceScriptable resource;
    [SerializeField] GameObject dropped;

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    public void DropResources()
    {
        if(timer <= 0)
        {
            timer = maxTimer;

            for(int b = 0;  b < amount; b++){
                ShootResource();
            }
        }
    }

    public void ShootResource()
    {
        int deg = Random.Range(0, 360);
        Vector3 dir = (Quaternion.Euler(0f, 0f, deg) * new Vector2(0, 1)).normalized;
        Instantiate(dropped, this.transform.position+dir, Quaternion.identity);
    }
}
