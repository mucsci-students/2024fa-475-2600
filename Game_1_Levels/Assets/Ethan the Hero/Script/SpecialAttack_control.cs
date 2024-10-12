using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack_control : MonoBehaviour
{
    public float timer = 0f;
    public GameObject ice_prefab;
    public GameObject lightning_prefab;
    public GameObject fire_prefab;

    private GameObject player;

    private string[] auraSprites = {"aura_ice_0","aura_lightning_0","aura_fire_0"};

    private List<GameObject> auras;

    private aura_control auraControl;

    private bool onCoolDown;

    

    // Start is called before the first frame update
    void Start()
    {
        onCoolDown = false;
        player = GameObject.FindWithTag("Player");
        auraControl = player.transform.gameObject.GetComponent<aura_control>();
        auras = new List<GameObject>();
        for(int i= 0 ; i < 3; i++){
            auras.Add(player.transform.Find(auraSprites[i])?.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        int index = -1;
        

        if (auraControl.auraActive){
            for(int i = 0 ; i < auras.Count;i++){
                if(auras[i]!= null && auras[i].activeInHierarchy){
                    index = i;
                }
            }
            if(onCoolDown){
                if(timer >= 2.8f){
                    onCoolDown = false;
                    timer = 0f;
                }else{
                    timer += Time.deltaTime;
                }
            }

            if(Input.GetMouseButtonDown(0) && !onCoolDown){
                float direction = Mathf.Sign(player.transform.localScale.x);
                
                if(index == 0){
                    Destroy(Instantiate(ice_prefab,new Vector3(player.transform.position.x + (ice_prefab.transform.position.x * direction),ice_prefab.transform.position.y,player.transform.position.z),ice_prefab.transform.rotation),3f);
                }else if(index == 1){
                    Destroy(Instantiate(lightning_prefab,new Vector3(player.transform.position.x + (lightning_prefab.transform.position.x * direction) ,lightning_prefab.transform.position.y,player.transform.position.z),lightning_prefab.transform.rotation),3f);
                }else{
                    Destroy(Instantiate(fire_prefab,new Vector3(player.transform.position.x + (fire_prefab.transform.position.x * direction),fire_prefab.transform.position.y,player.transform.position.z),fire_prefab.transform.rotation),3f);
                }
                onCoolDown = true;
            }
                
        }
    }
}
