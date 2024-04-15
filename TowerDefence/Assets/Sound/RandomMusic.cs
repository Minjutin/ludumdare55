using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public List<AudioSource> music;
    public AudioSource Current;


    private void Start()
    {
        PlayAudio();
        InvokeRepeating("checkMusic", 2.0f, 2.0f);
    }

    private void PlayAudio()
    {
        int rand = Random.Range(0, music.Count);
        music[rand].Play();
        Current = music[rand];
    }

    void checkMusic()
    {
        if (!Current.isPlaying)
            PlayAudio();
        else
            Debug.Log("Playing music");

    }
}
