using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public HealthManager script;
    public Respawn respawner;
    public Transform StartSpawnPoint;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform BossSpawnPoint;
    private Transform currentSpawnPoint;
    private GameObject player;
    public bool isDie = false;
    public int currentLevel;

    void Start ()
    {
        currentSpawnPoint = StartSpawnPoint;
        player = GameObject.FindWithTag("Player");
        PositionPlayer();
    }

    public void PositionPlayer()
	{
		player.transform.position = currentSpawnPoint.transform.position;
        script.heal(200);
        isDie = false;
	}

    public void setSpawnPoint(int spawnpoint)
    {
        if (spawnpoint == 0)
        {
            currentSpawnPoint = StartSpawnPoint;
        }
        else if (spawnpoint == 1)
        {
            currentSpawnPoint = SpawnPoint1;
        }
        else if (spawnpoint == 2)
        {
            currentSpawnPoint = SpawnPoint2;
        }
        else if (spawnpoint == 3)
        {
            currentSpawnPoint = BossSpawnPoint;
        }
    }
    void Update ()
	{
		if (isDie)
		{
            respawner.Die();
            
		}
	}
}
