using System.Collections;
using System.Collections.Generic;
using EthanTheHero;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Manager script;
    public Image healthBar;
    public PlayerAnimation animScript;
     private float timer = 0f;
    public float healthAmount = 100f;

    void Update()
    {
        if(healthAmount <= 0)
        {
            timer += Time.deltaTime;
            if(timer >= 1.35)
            {
                timer = 0;
                script.isDie = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            takeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            heal(20);
        }
    }

    public void takeDamage (float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
        if (healthAmount > 0)
            animScript.isHurt = true;
        else
            animScript.isDead = true;
    }

    public void heal (float healAmount)
    {
        healthAmount += healAmount;
        healthAmount= Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
