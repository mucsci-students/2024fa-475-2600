using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Manager script;
    public int spawn = 1;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            script.setSpawnPoint(spawn);
        }
    }
}
