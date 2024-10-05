using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Manager script;
    public Image healthBar;
    public float healthAmount = 100f;

    void Update()
    {
        if(healthAmount <= 0)
        {
            script.isDie = true;
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
    }

    public void heal (float healAmount)
    {
        healthAmount += healAmount;
        healthAmount= Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
