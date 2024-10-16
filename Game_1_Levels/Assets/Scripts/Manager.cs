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
    public int currentLevel;
    public int spawnVal = 0;

    void Start ()
    {
        Time.timeScale = 1;
        spawnVal = (PlayerPrefs.GetInt("tempspawn") - 3) / 11;
        setSpawnPoint(spawnVal);
        player = GameObject.FindWithTag("Player");
        PositionPlayer();
    }
    public void PositionPlayer()
	{
		player.transform.position = currentSpawnPoint.transform.position;
        SoundFXManager.instance.PlaySoundFXClip(script.regenSound, transform, 0.1f);
        script.currentHealth = 1;
        script.healthBar.fillAmount = script.currentHealth / script.maxHealth;
	}
    public void setSpawnPoint(int spawnpoint)
    {
        spawnVal = spawnpoint;
        if (spawnpoint == 1)
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
        else
        {
            currentSpawnPoint = StartSpawnPoint;
        }
    }
    public void Die()
    {
        //noise since playerprefs is public
        PlayerPrefs.SetInt("tempspawn", (spawnVal * 11) + 3);
        respawner.Die();
    }
}