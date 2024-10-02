using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
   
    void OnTriggerEnter2D (Collider2D other)
    {
        print(other.gameObject.name + " has entered the cube");
    }
}
