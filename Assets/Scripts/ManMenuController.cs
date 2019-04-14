using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManMenuController : MonoBehaviour {

    public Text hs;
    public GameObject inf;
    bool isInf;
    bool isCalledYet;

    const int bootScene = 0;
    static bool firstCall = true;

    void Awake()
    {
        if (firstCall)
        {
            programBegins();
            firstCall = false;
        }
        else if (firstCall == false)
        {
            initializeScene();
            //DestroyObject(gameObject);
        }
    }

	// Use this for initialization
	void Start () 
    {
        //HSFunction();
        //inf.SetActive(true);
        //isInf = true;
        
        
	}

    void initializeScene()
    {
        HSFunction();
    }
    void programBegins()
    {
        HSFunction();
        inf.SetActive(true);
        isInf = true;
    }
	// Update is called once per frame
	void Update () 
    {
        if (isInf == false)
        {
            inf.SetActive(false);
            
        }
        else
        {
            inf.SetActive(true);
            
        }
     }

     public void showPreMenu()
      {
          isInf = false;
          
     }
    public void  Play(string ex)
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

       

   public  void Authors(string auth)
    {
        SceneManager.LoadScene(auth);
        
    }
}
