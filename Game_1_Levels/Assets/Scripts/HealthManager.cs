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
    [SerializeField] private AudioClip deathSound;
	[SerializeField] public AudioClip hurtSound;
    [SerializeField] public AudioClip healSound;
    [SerializeField] public AudioClip superHealSound;
    [SerializeField] public AudioClip regenSound;
    private float timer = 0f;
    private float regenTimer = 0f;
    public float currentHealth = 1f;
    public float maxHealth = 100f;
    public float lerpSpeed;
    public bool isWallSliding = false;
    
    void Update()
    { 
        //if game paused don't do anything
        if(Time.timeScale == 0){
            return;
        }
        regenTimer += Time.deltaTime;
        if (regenTimer < 3)
        {
            lerpSpeed = 2f * Time.deltaTime;
            float newFill = Mathf.Lerp (healthBar.fillAmount, currentHealth, lerpSpeed);
            heal(newFill - healthBar.fillAmount);
            
        }

        if(currentHealth <= 0)
        {
            timer += Time.deltaTime;
            if(timer >= 1.35)
            {
                timer = 0;
                regenTimer = 0;
                script.Die();
            }
            return;
        }
        
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     takeDamage(20);
        // }

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     heal(20);
        // }
    }

    public void takeDamage (float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;
        if (currentHealth > 0)
        {
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, 0.1f);
            if (isWallSliding == false)
            {
                animScript.isHurt = true;
            }
        }
            
        else
        {

            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.2f);
            animScript.isDead = true;
        }
            
    }

    public void heal (float healAmount)
    {
        currentHealth += healAmount;
        currentHealth= Mathf.Clamp(currentHealth, 0, 100);
        healthBar.fillAmount = currentHealth / 100f;
        if (healAmount > 10f && healAmount < 50f)
        {
            SoundFXManager.instance.PlaySoundFXClip(healSound, transform, 0.2f);
        }
        else if (healAmount == 250f)
        {
            SoundFXManager.instance.PlaySoundFXClip(superHealSound, transform, 0.2f);
        }
    }
}
