using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour {

        
	// Use this for initialization
    public static AudioMenu instance;
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
}
	// Update is called once per frame
	void Update () {
		
	}


    public void delete()
    {
        Destroy(gameObject);
        //DestroyObject(gameObject);
    }

}
