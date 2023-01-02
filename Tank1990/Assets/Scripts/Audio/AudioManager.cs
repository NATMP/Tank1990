using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Audio[] audios;
    private void Awake()
    {
        foreach(Audio audio in audios)
        {
            audio.source=gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;

            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.loop;
        }
    }
    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        Play("Theme");
        DontDestroyOnLoad(this.gameObject);
    }
    public void Play(string name)
    {
        Audio a = Array.Find(audios,audio =>audio.name==name);
        a.source.Play();
    }
}
