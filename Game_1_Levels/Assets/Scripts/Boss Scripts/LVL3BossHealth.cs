using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL3BossHealth : MonoBehaviour
{
    public Image bossHealthBar;
    public KnightPatrol script;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Sword" && script.isDead == false)
        {
            bossHealthBar.fillAmount = script.health / 1000f;
        }
    }
}
