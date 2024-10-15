using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EthanTheHero
{
        
    public class SpecialAttack_control : MonoBehaviour
    {
        public float timer = 0f;
        public GameObject ice_prefab;
        public GameObject lightning_prefab;
        public GameObject fire_prefab;

        [SerializeField] private AudioClip fireSound;
        [SerializeField] private AudioClip lightningSound;
        [SerializeField] private AudioClip iceSound;

        private GameObject player;

        private PlayerMovement playerMv;

        private string[] auraSprites = {"aura_ice_0","aura_lightning_0","aura_fire_0"};

        private List<GameObject> auras;

        private aura_control auraControl;

        public bool onCoolDown;

        private int index;

        void Awake()
        {
            playerMv = GetComponent<PlayerMovement>();
        }
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
            index = -1;
            if (auraControl.auraActive){
                for(int i = 0 ; i < auras.Count;i++){
                    if(auras[i]!= null && auras[i].activeInHierarchy){
                        index = i;
                    }
                }
                if(onCoolDown){
                    if( timer >= .8f && index != 2||timer >= 2.5f ){
                        onCoolDown = false;
                        timer = 0f;
                    }else{
                        timer += Time.deltaTime;
                    }
                }

                if(Input.GetMouseButtonDown(0) && !onCoolDown && playerMv.grounded){
                    float direction = Mathf.Sign(player.transform.localScale.x);
                    
                    if(index == 0){
                        SoundFXManager.instance.PlaySoundFXClip(iceSound, transform, .3f);
                        Destroy(Instantiate(ice_prefab,new Vector3(player.transform.position.x + (ice_prefab.transform.position.x * direction),player.transform.position.y + ice_prefab.transform.position.y,player.transform.position.z),ice_prefab.transform.rotation),.5f);
                    }else if(index == 1){
                        SoundFXManager.instance.PlaySoundFXClip(lightningSound, transform, .3f);
                        Destroy(Instantiate(lightning_prefab,new Vector3(player.transform.position.x + (lightning_prefab.transform.position.x * direction) ,player.transform.position.y + lightning_prefab.transform.position.y,player.transform.position.z),lightning_prefab.transform.rotation),.8f);
                    }else{
                        SoundFXManager.instance.PlaySoundFXClip(fireSound, transform, .2f);
                        Destroy(Instantiate(fire_prefab,new Vector3(player.transform.position.x + (fire_prefab.transform.position.x * direction),player.transform.position.y + fire_prefab.transform.position.y,player.transform.position.z),fire_prefab.transform.rotation),2.5f);
                    }
                    onCoolDown = true;
                }              
            }
        }

        void OnTriggerEnter2D (Collider2D other)
        {
            if(other.tag != "Player" && other.tag != "Sword")
            {
                float[] damages = {10f, 10f, 15f};//ice, lightning, and fire
                if (index > -1 && index < 3)
                {
                    if (other.tag == "Slime")
                    {
                        other.GetComponent<SlimeMovement>().health -= damages[index];
                    }
                    else if (other.tag == "Knight")
                    {
                        other.GetComponent<KnightPatrol>().health -= damages[index];
                    }
                    else if (other.tag == "Skeleton")
                    {
                        other.GetComponent<SkeletonMovement>().health -= damages[index];
                    }
                }
            }
        }
    }
}