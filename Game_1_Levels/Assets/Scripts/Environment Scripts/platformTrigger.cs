using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTrigger : MonoBehaviour
{
    private GameObject movingPlatform;
    private Animator anim;
    void Start()
    {
        movingPlatform = GameObject.FindWithTag("movingPlatform");
        anim = movingPlatform.GetComponent<Animator>();
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("onPlatform", true);
        }
        
        
    }
}
