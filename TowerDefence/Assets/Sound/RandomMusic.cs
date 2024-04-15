using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public List<AudioSource> music;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, music.Count);
        music[rand].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
