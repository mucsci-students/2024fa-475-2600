using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    // declared components
    private Animator anim;
    private Rigidbody2D body;
    private Transform targetPoint;
    private SpriteRenderer rend;
    // field values
    public float health = 60;
    //sound effects
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    // linked objects
    public HealthManager script;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject heartPrefab;
    //internal variables
    public float speed = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        targetPoint = pointA.transform;
        anim.SetBool("isRunning", true);
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(Time.timeScale == 0 || !anim.GetBool("isRunning"))
        {
            return;
        }
        healthCheck();
        int negative = -1;
        if (targetPoint == pointB.transform)
        {
            negative *=-1;
        }
        body.velocity = new Vector2(speed*negative, 0);
        
        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < 0.5f)
        {
            flip();
            anim.SetBool("isRunning", false);
            StartCoroutine(goIdle());
            if(targetPoint == pointB.transform)
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
    void randomHeart()
    {
        int random = Random.Range(0, 10); // 0 - 9
        Transform temp = this.transform;
        if (random < 3)
        {
            Instantiate(heartPrefab, temp.position, Quaternion.identity);
        }
    }

    IEnumerator goIdle() 
    {
        yield return new WaitForSeconds (2f);
        anim.SetBool("isRunning", true);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            health -=10;
            if(health <=0)
            {
                anim.SetTrigger("death");
                SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.3f);
                Destroy(transform.parent.gameObject, 0.5f);
                randomHeart();
            }
            else
            {
                anim.SetTrigger("hurt");
                SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, .2f);
                StartCoroutine(takeDamage());
            } 
        }
    }
    private void healthCheck()
    {
        if(health <= 0)
        {
            anim.SetTrigger("death");
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.3f);
            Destroy(transform.parent.gameObject, 0.5f);
            randomHeart();
        }
    }
    public void startAttack()
    {
        anim.SetBool("isRunning", false);
        anim.SetTrigger("attack");
        StartCoroutine(attack());
    }

    IEnumerator attack()
    {
        healthCheck();
        //isAttack = false;
        yield return new WaitForSeconds (.5f);
        //audioSource.PlayOneShot(clip, 2f);
        //audioSource.Play();
        yield return new WaitForSeconds (.5f);
        //SoundFXManager.instance.PlaySoundFXClip(attackSound, transform, 2f);
        anim.SetBool("isRunning", true);
    }
    IEnumerator takeDamage()
    {
        rend.enabled = false;
        yield return new WaitForSeconds (.1f);
        rend.enabled = true;
        yield return new WaitForSeconds (.1f);
        rend.enabled = false;
        yield return new WaitForSeconds (.1f);
        rend.enabled = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}

