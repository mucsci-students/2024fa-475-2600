using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnightPatrol : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip clip;

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    public Animator anim;
    private Transform currentPoint;
    public float speed;
    public bool isAttack = false;
    public float health = 100f;
    private bool myTargetValid;
    [SerializeField] private AudioClip attackSound;
	[SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    private SpriteRenderer rend;
    public GameObject heartPrefab;
    public bool isDead = false;
    public float playerSwordDamage = 5f;

    public GameObject attackHitBox;
    // private Vector3 localScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
        myTargetValid = true;
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        // localScale = transform.localScale;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform && myTargetValid)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (currentPoint == pointA.transform && myTargetValid)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        // if (currentPoint == pointB.transform)
        // {
        //     rb.velocity = new Vector2(speed, 0);
        // }
        // else
        // {
        //     rb.velocity = new Vector2(-speed, 0);
        // }


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
            // isAttack = false;
            // localScale.x = -1;
            // transform.localScale = localScale;
            // myTargetValid = false;
            // anim.SetBool("isRunning", false);
            // StartCoroutine(goIdle(0));

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
            //isAttack = false;
            // myTargetValid = false;
            // anim.SetBool("isRunning", false);
            // StartCoroutine(goIdle(1));
        }
        // if (isAttack)
        // {
        //     myTargetValid = false;
        //     anim.SetBool("isRunning", false);
        //     anim.SetTrigger("attack");
        //     StartCoroutine(attack());
        // }
        healthCheck();
    }

    private void healthCheck()
    {
        if(health <= 0f && isDead == false)
        {
            anim.SetBool("isRunning", false);
            myTargetValid = false;
            isDead = true;
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.1f);
            StartCoroutine(death());
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Sword" && isDead == false)
        {
            //Debug.Log("Health is " + Health);
            SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, .25f);
            StartCoroutine(takeDamage());
            health -= playerSwordDamage;
            if(health <= 0f)
            {
                //SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.1f);
                Destroy(attackHitBox);
            }
        }
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
    public void startAttack()
    {
        myTargetValid = false;
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
        audioSource.Play();
        yield return new WaitForSeconds (.5f);
        //SoundFXManager.instance.PlaySoundFXClip(attackSound, transform, 2f);
        anim.SetBool("isRunning", true);
        myTargetValid = true;
    }

    IEnumerator death()
    {
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds (2f);
        //SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.1f);
        Destroy(this.gameObject);
        randomHeart();
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

    // IEnumerator goIdle(int point) 
    // {
    //     healthCheck();
    //     yield return new WaitForSeconds (2f);
    //     anim.SetBool("isRunning", true);
    //     myTargetValid = true;
    //     healthCheck();

    //     if(point == 0)
    //     {
    //         currentPoint = pointA.transform;
    //     }
    //     else
    //     {
    //         currentPoint = pointB.transform;
    //     }
    // } 
}
