using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour {

    
    Color[] colors = new Color[6];


	// Use this for initialization
	void Start ()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.magenta;
        colors[4] = Color.yellow;
        colors[5] = Color.cyan;


	}

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }
	
}
