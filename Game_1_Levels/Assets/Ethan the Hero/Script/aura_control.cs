using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aura_control : MonoBehaviour
{
    public float timer = 0f;
    public bool auraActive = false;

    private GameObject player;
    // Start is called before the first frame update

    private string[] auraSprites = {"aura_ice_0","aura_lightning_0","aura_fire_0"};

    private List<GameObject> auras;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        auras = new List<GameObject>();
        for(int i= 0 ; i < 3; i++){
            auras.Add(player.transform.Find(auraSprites[i])?.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = -1;
        if(Time.timeScale != 0 && auraActive){
            
            for(int i = 0 ; i < auras.Count;i++){
                if(auras[i]!= null && auras[i].activeInHierarchy){
                    index = i;
                }
            }

            timer += Time.deltaTime;
            if(timer >= 15f && index != -1){
                if(auras[index]!=null){
                    player.transform.Find(auraSprites[index]).gameObject.SetActive(false);
                }
                auraActive = false;
                timer = 0f;
            }
        }
    }
}
