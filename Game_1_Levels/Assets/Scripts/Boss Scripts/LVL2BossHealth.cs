using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL2BossHealth : MonoBehaviour
{
    public Image bossHealthBar;
    public SkeletonMovement script;
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
        if (other.tag == "Sword" || other.tag == "PowerUp")
        {
            bossHealthBar.fillAmount = script.health / 750f;
            if(script.health < 20){
                Win();
            }
        }
    }
}
