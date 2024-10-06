using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestTrigger : MonoBehaviour
{
    private GameObject chest;
    private Animator anim;

    public GameObject prefab;
    public Transform spawnPoint;


    void Start()
    {

        chest = GameObject.FindWithTag("Chest");
        anim =  GetComponent<Animator>();
    }

   void OnTriggerEnter2D (Collider2D other)
    {
       if(anim.GetBool("isClosed")){
        Instantiate(prefab,spawnPoint.position,spawnPoint.rotation);
        anim.SetBool("isClosed",false);
       }
       
    }
}
