using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCheckpoint : MonoBehaviour
{
    private GameObject player;
    public Transform spawnPoint;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void OnTriggerEnter2D()
	{
		player.transform.position = spawnPoint.position;
	}

}
