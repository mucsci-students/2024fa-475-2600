using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private HealthManager script;
    public int damage = 10;

    void Start()
    {
        script = GameObject.FindObjectOfType<HealthManager>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            script.takeDamage(damage);
        }
    }
}
