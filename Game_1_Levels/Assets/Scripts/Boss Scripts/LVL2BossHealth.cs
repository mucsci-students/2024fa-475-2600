using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL2BossHealth : MonoBehaviour
{
    public Image bossHealthBar;
    public SkeletonMovement script;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "PowerUp")
        {
            bossHealthBar.fillAmount = script.health / 750f;
        }
    }
}
