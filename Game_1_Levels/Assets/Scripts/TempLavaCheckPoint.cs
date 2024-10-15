using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempLavaCheckPoint : MonoBehaviour
{
    public Manager script;
    public int spawn = 0;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            script.setSpawnPoint(spawn);
        }
    }
}
