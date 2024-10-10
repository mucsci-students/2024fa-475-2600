using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestTrigger : MonoBehaviour
{
    private GameObject chest;
    private Animator anim;

    public GameObject prefab;
    public Transform spawnPoint;
    [SerializeField] private AudioClip chestOpen;


    void Start()
    {

        chest = GameObject.FindWithTag("Chest");
        anim =  GetComponent<Animator>();
    }

   void OnTriggerEnter2D (Collider2D other)
    {
     if(other.tag=="Sword"){
        Debug.Log("Object entered: " + other.gameObject.name + " with tag: " + other.tag);
          if(anim.GetBool("isClosed"))
          {
            Instantiate(prefab,spawnPoint.position,spawnPoint.rotation);
            anim.SetBool("isClosed",false);
            SoundFXManager.instance.PlaySoundFXClip(chestOpen, transform, .3f);
          }
     }
       
    }
}
