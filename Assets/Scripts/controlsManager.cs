using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlsManager : MonoBehaviour {

    public void returns(string ext)
    {
        SceneManager.LoadScene(ext);
    }
}
