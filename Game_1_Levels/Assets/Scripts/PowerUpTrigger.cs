using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    private GameObject powerUp;

    void Start(){
        powerUp = GameObject.FindWithTag("PowerUp");
    }
    void OnTriggerEnter2D (Collider2D other)
    {
     
     Destroy(powerUp);
     print("PowerUp Destroyed");
    }
}
