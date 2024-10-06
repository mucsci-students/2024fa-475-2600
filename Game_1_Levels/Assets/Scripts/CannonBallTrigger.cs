using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallTrigger : MonoBehaviour
{
    private GameObject cannonBall;
    private Animator anim;

    void Start()
    {
        cannonBall = GameObject.FindWithTag("cannonBall");
        anim = cannonBall.GetComponent<Animator>();
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        anim.SetBool("inRange", true);
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        anim.SetBool("inRange", false);
    }
}
