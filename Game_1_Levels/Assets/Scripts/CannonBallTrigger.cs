using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallTrigger : MonoBehaviour

{
    private float timer = 0f;
    private GameObject cannonBall;
    private Animator anim;
    private bool inCollider = false;
    [SerializeField] private AudioClip cannonFire;

    void Start()
    {
        cannonBall = GameObject.FindWithTag("cannonBall");
        anim = cannonBall.GetComponent<Animator>();
    }

    void Update()
    {
        if (inCollider)
        {
            timer += Time.deltaTime;
            if(timer >= 5f)
            {
                SoundFXManager.instance.PlaySoundFXClip(cannonFire, transform, .1f);
                timer = 0f;
            }
        }
    
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            inCollider = true;
            SoundFXManager.instance.PlaySoundFXClip(cannonFire, transform, .1f);
            anim.SetBool("inRange", true);
        }
        
        
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            inCollider = false;
            anim.SetBool("inRange", false);
        }
    }
}
