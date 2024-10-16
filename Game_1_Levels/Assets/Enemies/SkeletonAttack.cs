using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
public SkeletonMovement script;
private float timer = 0f;

    void OnTriggerEnter2D (Collider2D other)
    { 
        if (other.tag == "Player" && script.isDead == false)
        {
            script.startAttack();
            timer = 0f;
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player" && script.isDead == false)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                script.startAttack();
                timer = 0f;
            }
        }
    }
}
