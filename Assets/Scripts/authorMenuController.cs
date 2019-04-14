using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class authorMenuController : MonoBehaviour 
{
    public void returns(string ex)
    {
        SceneManager.LoadScene(ex);
       
    }
    
}
