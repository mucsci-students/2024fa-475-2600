using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHB : MonoBehaviour
{
    public KnightPatrol script;
    private float timer = 0f;


    void OnTriggerEnter2D (Collider2D other)
    { 
        if (other.tag == "Player")
        {
            script.startAttack();
            timer = 0f;
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player")
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
