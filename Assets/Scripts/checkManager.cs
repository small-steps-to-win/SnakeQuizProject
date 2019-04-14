using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkManager : MonoBehaviour {

    public AudioSource inp;
	
	void Start () 
    {
        inp = GameObject.FindObjectOfType<AudioSource>();
	}

    public void pauseMusic()
    {
        inp.Pause();

    }
    public void unPauseMusic()
    {
        inp.UnPause();
    }
	
}
