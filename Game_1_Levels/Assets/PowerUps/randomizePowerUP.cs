using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizePowerUP : MonoBehaviour
{
   private GameObject powerUp;

   

   string[] powerUpSprites = {"GEM 3 - TURQUOISE - Spritesheet_0","GEM 3 - GOLD - Spritesheet_0","GEM 3 - RED - Spritesheet_0"};

    void Start(){
        int powerUpId = Random.Range(0,3);
        powerUp = GameObject.FindWithTag("PowerUp");
        powerUp.transform.Find(powerUpSprites[powerUpId]).gameObject.SetActive(true);
    }
}
