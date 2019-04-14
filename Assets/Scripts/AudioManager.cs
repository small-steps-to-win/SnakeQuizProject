using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource inputz;
    public SoundClass[] sounds;
    public static AudioManager instance;
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        foreach (SoundClass s in sounds)
        {
             s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }
    void Start()
    {
       Play("Theme");
      inputz = GameObject.FindObjectOfType<AudioSource>();
       //inputz = GetComponent<AudioSource>();
        
        
    }

    public void Play(string name)
    {
       SoundClass s = Array.Find(sounds,sound => sound.name == name);
       if (s == null)
       {
           Debug.LogWarning("Sound " + name + " not found!");
       }
           s.source.Play();
        
    }

    void Update()
    {
       
    }

    

    public void delete()
    {
        Destroy(gameObject);
        //DestroyObject(gameObject);
        
    }
    
}
