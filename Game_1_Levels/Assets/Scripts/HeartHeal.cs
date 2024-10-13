using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    private HealthManager script;
    public float healAmount = 25f;

    void Start()
    {
        script = GameObject.FindObjectOfType<HealthManager>();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            script.heal(healAmount);
            Destroy(this.gameObject);
        }
    }
}
