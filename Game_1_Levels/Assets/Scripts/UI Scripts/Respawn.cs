using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private GameObject player;
    private GameObject screen;
    public Manager script;
    
    void Start() 
    {   
        player = GameObject.FindWithTag("Player");
        screen = GameObject.Find("RespawnScreen");
        screen.SetActive(false);
    }
    public void Die()
    {
        Time.timeScale = 0;
        screen.SetActive(true);
    }
    public void Restart()
    {
        player.transform.Find("aura_ice_0").gameObject.SetActive(false);
        player.transform.Find("aura_lightning_0").gameObject.SetActive(false);
        player.transform.Find("aura_fire_0").gameObject.SetActive(false);
        player.transform.gameObject.GetComponent<aura_control>().auraActive = false;
        screen.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(script.currentLevel);
        //script.PositionPlayer();
    }
    public void ExitToMenu()
    {
        PlayerPrefs.SetInt("tempspawn", 3);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}