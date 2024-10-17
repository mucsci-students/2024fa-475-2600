using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_controller : MonoBehaviour
{
    private GameObject healthPack;
    // Start is called before the first frame update
    void Start()
    {
        healthPack = gameObject;
    }

     void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player"){
        // add your health or other desired functionality here
        Destroy(healthPack);
        //print("Health pack Destroyed");
        }
    }
}
