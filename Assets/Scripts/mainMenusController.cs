using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenusController : MonoBehaviour {

    public Text hs;
    

    // Use this for initialization
    void Start()
    {
        HSFunction();
        
    }


    // Update is called once per frame
    void Update()
    {


    }
    
    public void Play(string ex)
    {
        SceneManager.LoadScene(ex);

    }

    void HSFunction()
    {
        hs.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }



    public void Authors(string auth)
    {
        SceneManager.LoadScene(auth);
    }
}
