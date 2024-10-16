using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL3BossHealth : MonoBehaviour
{
    public Image bossHealthBar;
    public KnightPatrol script;
    private GameObject screen;

    void Start()
    {
        screen = GameObject.Find("WinScreen");
        screen.SetActive(false);
    }
    public void Win()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("tempspawn", 3);
        screen.SetActive(true);
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Sword" && script.isDead == false)
        {
            bossHealthBar.fillAmount = script.health / 1000f;
            if(script.health < 20){
                Win();
            }
            // if(script.Health <= 0f)
            // {
            //     Destroy(this.gameObject);
            // }
        }
    }
}
