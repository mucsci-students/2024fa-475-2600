using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestTrigger : MonoBehaviour
{
    private GameObject chest;
    private Animator anim;

    void Start()
    {
        chest = GameObject.FindWithTag("Chest");
        anim =  GetComponent<Animator>();
    }

   void OnTriggerEnter2D (Collider2D other)
    {
       anim.SetBool("isClosed",false);
    }
}
