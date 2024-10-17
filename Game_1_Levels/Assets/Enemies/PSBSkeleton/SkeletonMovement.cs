using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    // declared components
    private Animator anim;
    private Rigidbody2D body;
    private Transform currentPoint;
    // field values
    public float health = 80f;

    private bool myTargetValid;
    //sound effects
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    // linked objects
    public HealthManager script;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject heartPrefab;
    //internal variables
    public float speed = 1;

    private float runTimer = 0f;
    private bool canRun;
    public bool isDead = false;

    public GameObject skeletonChild;
    public GameObject attackHitBox;
    public float playerSwordDamage = 5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
        anim.SetTrigger("MoveTrigger");
        myTargetValid = true;
        canRun = true;
    }
    void Update()
    {
        runTimer += Time.deltaTime;
        if (runTimer >= 1.33f)
        {
            if (canRun && isDead == false)
            {
                anim.SetTrigger("MoveTrigger");
            }
            runTimer = 0f;
        }
        if(Time.timeScale == 0)
        {
            return;
        }
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform && myTargetValid)
        {
            body.velocity = new Vector2(speed, 0);
        }
        else if (currentPoint == pointA.transform && myTargetValid)
        {
            body.velocity = new Vector2(-speed, 0);
        }
        
        if (Mathf.Abs(transform.position.x - currentPoint.position.x) < .75f)
        {
            flip();
            if(currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            else
            {
                currentPoint = pointB.transform;
            }
        }
        healthCheck();
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" && isDead == false)
        {
            health -= playerSwordDamage;
            if(health <=0)
            {
                //SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.25f);
                //myTargetValid = false;
                anim.SetTrigger("DeathTrigger");
            }
            else
            {
                SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, .2f);
                StartCoroutine(takeDamage());
            } 
        }
    }
    private void healthCheck()
    {
        if(health <= 0 && isDead == false)
        { 
            myTargetValid = false;
            Destroy(attackHitBox);
            canRun = false;
            isDead = true;
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.25f);
            StartCoroutine(death());
        }
    }
    public void startAttack()
    {
        //anim.SetBool("isRunning", false);
        healthCheck();
        canRun = false;
        myTargetValid = false;
        anim.SetTrigger("AttackTrigger");
        SoundFXManager.instance.PlaySoundFXClip(attackSound, transform, .2f);
        StartCoroutine(attack());
    }

    IEnumerator attack()
    {
        healthCheck();
        yield return new WaitForSeconds (.5f);
        myTargetValid = true;
        canRun = true;
    }
    IEnumerator takeDamage()
    {
        skeletonChild.SetActive(false);
        yield return new WaitForSeconds (.1f);
        skeletonChild.SetActive(true);
        yield return new WaitForSeconds (.1f);
        skeletonChild.SetActive(false);
        yield return new WaitForSeconds (.1f);
        skeletonChild.SetActive(true);
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds (1f);
        //SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 0.1f);
        Destroy(gameObject);
        randomHeart();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.75f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.75f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}

