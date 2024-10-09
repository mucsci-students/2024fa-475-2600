using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    string[] auras = {"aura_ice_0","aura_lightning_0","aura_fire_0"};
    string[] powerUpSprites = {"GEM 3 - TURQUOISE - Spritesheet_0","GEM 3 - GOLD - Spritesheet_0","GEM 3 - RED - Spritesheet_0"};
    private GameObject powerUp;

    void Start(){
        powerUp = this.gameObject;
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player"){
            //Choose which aura to activate on the player

        //ice
        if(powerUp.transform.Find(powerUpSprites[0]).gameObject.activeSelf){
            other.transform.Find(auras[0]).gameObject.SetActive(true);
            other.transform.Find(auras[1]).gameObject.SetActive(false);
            other.transform.Find(auras[2]).gameObject.SetActive(false);
            other.transform.gameObject.GetComponent<aura_control>().timer = 0f;
        //lightning
        }else if(powerUp.transform.Find(powerUpSprites[1]).gameObject.activeSelf){
            other.transform.Find(auras[0]).gameObject.SetActive(false);
            other.transform.Find(auras[1]).gameObject.SetActive(true);
            other.transform.Find(auras[2]).gameObject.SetActive(false);
            other.transform.gameObject.GetComponent<aura_control>().timer = 0f;
        //fire
        }else
        {
            other.transform.Find(auras[0]).gameObject.SetActive(false);
            other.transform.Find(auras[1]).gameObject.SetActive(false);
            other.transform.Find(auras[2]).gameObject.SetActive(true);
            other.transform.gameObject.GetComponent<aura_control>().timer = 0f;
        }
        aura_control auraControl = other.transform.gameObject.GetComponent<aura_control>();
        
        auraControl.auraActive = true;
        
        Destroy(powerUp);
        print("PowerUp Destroyed");
        }
    }
}