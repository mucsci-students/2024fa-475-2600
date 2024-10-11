using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private bool facingLeft = true;

    [SerializeField] private float health;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "sword")
        {
            health -=10;
            if(health <=0 ){
                anim.SetTrigger("hurt");
            }
            
        }
    }
}
