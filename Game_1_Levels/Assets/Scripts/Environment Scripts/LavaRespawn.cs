using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRespawn : MonoBehaviour
{
    private GameObject player;
    public Transform spawnPoint;
    public Transform newSpawn;
    public Transform secondNewSpawn;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D()
	{
		player.transform.position = spawnPoint.position;
	}
}
