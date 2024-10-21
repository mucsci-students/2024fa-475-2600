using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCheckpoint : MonoBehaviour
{
    public Manager script;
    public LavaRespawn script2;
    public Transform orignalLavaSpawn;
    public Transform newLavaSpawn;
    public int spawn = 1;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (spawn == 4)
            {
                script2.spawnPoint = orignalLavaSpawn;
            }
            else if (spawn == 5)
            {
                script2.spawnPoint = script2.newSpawn;
            }
            else if (spawn == 6)
            {
                script2.spawnPoint = newLavaSpawn;
            }
            else
            {
                script.setSpawnPoint(spawn);
            }
            
        }
    }
}
