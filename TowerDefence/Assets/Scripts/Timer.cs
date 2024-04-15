using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float levelTime = 30; //as seconds
    public float t=1;

    // Update is called once per frame

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(t, 1, 1);
        t -= Time.fixedDeltaTime / levelTime;

        if (t < 0)
        {
            GameManager.instance.NextLevel();
            t = 1;
        }
    }

    public void StartAgain()
    {
        t = 1;
    } 
}
