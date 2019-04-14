using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour {

   

    public AudioClip[] audioClip;
    public AudioSource input;


	// Use this for initialization
	void Start () {
        input = GetComponent<AudioSource>();
        PlaySound(Random.Range(0,audioClip.Length));
       
        
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    
    public void PauseSound()
    {
        input.Pause();
    }
    public void UnPauseSound()
    {
        input.UnPause();
    }

    void PlaySound(int clip)
    {
        input.clip = audioClip[clip];
        input.Play();
    }

    void StopSound(int clip)
    {
        input.clip = audioClip[clip];
        input.Stop();
    }
}
