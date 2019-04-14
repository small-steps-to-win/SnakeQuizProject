using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class katController : MonoBehaviour {
    public  AudioManager musicInstance;
    
    public GameObject inf;
    bool isInf;
    void Start()
    {
        inf.SetActive(false);
        isInf = false;
        musicInstance = GameObject.FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (isInf == true)
        {
            inf.SetActive(true);
        }
        else
        {
            inf.SetActive(false);
        }
    }

    public void destroySound()
    {
        musicInstance.inputz.Stop();
    }

    public void showInfo()
    {
        isInf = true;
    }

    public void ok()
    {
        isInf = false;
    }
    public void gram(string ex)
    {
        SceneManager.LoadScene(ex);
    }

    public void mat(string ex)
    {
        SceneManager.LoadScene(ex);
    }
    
    public void rtr(string ex)
    {
        SceneManager.LoadScene(ex);
    }

    

    
}
