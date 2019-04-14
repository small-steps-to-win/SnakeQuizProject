using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour 
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    //public void Start()
    //{
    //    loadingScreen.SetActive(false);
    //}
    public void loadLevel(string ex)
    {
        StartCoroutine(LoadAsych(ex));
    }

    IEnumerator LoadAsych(string Name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressText.text = progress * 100f + "%";
            yield return null;
            
            
        }
    }
}
