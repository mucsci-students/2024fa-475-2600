using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LVL1BossHealth : MonoBehaviour
{
    public Image bossHealthBar;
    public SlimeMovement script;
    public HealthManager hmScript;
    public float slimeDamage = 10f;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Sword" || other.tag == "PowerUp")
        {
            bossHealthBar.fillAmount = script.health / 500f;
        }
        else if (other.tag == "Player"){
            hmScript.takeDamage(slimeDamage);
        }
    }
}
