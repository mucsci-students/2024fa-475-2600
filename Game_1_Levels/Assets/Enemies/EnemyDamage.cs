using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthManager script;
    public int damage;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            script.takeDamage(damage);
        }
    }
}
