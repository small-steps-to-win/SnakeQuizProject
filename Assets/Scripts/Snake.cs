using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;




public class Snake : MonoBehaviour {

    public Snake next;
       

          
   
    public static Action<String> hit;
    

    //setter
      public void Setnext(Snake IN)
    {
        next = IN;
    }
    //getter
    public Snake GetNext()
    {
        return next;
    }

    public void RemoveTail()
    {
        Destroy(this.gameObject);
    }
    //eat
    void OnTriggerEnter(Collider other)
    {
        if (hit != null)
        {
            hit(other.transform.tag);
        }
        if (other.tag == "Food")
        {
            
            Destroy(other.gameObject);
                                    
        }
     }
    
}
