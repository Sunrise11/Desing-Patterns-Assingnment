using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goal : MonoBehaviour
{

    public event Action Victory = delegate { };

     private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Victory.Invoke();
        }
    }
}
