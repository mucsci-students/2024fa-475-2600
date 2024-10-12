using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // declared components
    private Animator anim;
    private Rigidbody2D body;
    private Transform targetPoint;
    // field values
    [SerializeField] private float health = 40;
    [SerializeField] private float damage = 10;
    // linked objects
    public HealthManager script;
    public GameObject pointA;
    public GameObject pointB;
    //internal variables
    public float speed = 1;
    public bool paused = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        targetPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0 || paused)
        {
            return;
        }
        int negative = -1;
        if (targetPoint == pointB.transform)
        {
            negative *=-1;
        }
        body.velocity = new Vector2(speed*negative, body.velocity.y);
        
        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < 0.5f)
        {
            Debug.Log("I should flip now");
            flip();
            anim.SetBool("isRunning", false);
            StartCoroutine(goIdle());
            anim.SetBool("isRunning", true);
            if(targetPoint == pointB)
            {
                targetPoint = pointA.transform;
            }
            else
            {
                targetPoint = pointB.transform;
            }
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    IEnumerator goIdle() 
    {
        paused = true;
        yield return new WaitForSeconds (2f);
        paused = false;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            health -=10;
            if(health <=0 ){
                anim.SetTrigger("death");
                Destroy(transform.parent.gameObject, 0.5f);
            }
            else{
                anim.SetTrigger("hurt");
            } 
        }
        else if(other.tag == "Player"){
            script.takeDamage(damage);
        }
    }
}
