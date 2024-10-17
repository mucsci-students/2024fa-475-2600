using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    // declared components
    private Animator anim;
    private Rigidbody2D body;
    private Transform targetPoint;
    private SpriteRenderer rend;
    // field values
    public float health = 30;
    [SerializeField] private float damage = 10;
    //sound effects
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;
    // linked objects
    public HealthManager script;
    public GameObject pointA;
    public GameObject pointB;
    //internal variables
    public float speed = 1;
    public bool isDead = false;
    public GameObject heartPrefab;
    public float playerSwordDamage = 10f;

    void Start()
    {

        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        targetPoint = pointB.transform;
        anim.SetBool("isRunning", true);
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(Time.timeScale == 0 || !anim.GetBool("isRunning"))
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
            flip();
            anim.SetBool("isRunning", false);
            if(targetPoint == pointB.transform)
            {
                targetPoint = pointA.transform;
            }
            else
            {
                targetPoint = pointB.transform;
            }
        }
        anim.SetBool("isRunning", true);
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
    // IEnumerator goIdle() 
    // {
    //     yield return new WaitForSeconds (2f);
    //     anim.SetBool("isRunning", true);
    // }
    public void healthCheck(){
        if(health <=0)
        {
            anim.SetBool("isRunning", false);
            isDead = true;
            anim.SetTrigger("death");
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, .3f);
            Destroy(transform.parent.gameObject, 0.5f);
            randomHeart();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword" && isDead == false)
        {
            health -= playerSwordDamage;

            if(health > 0)
            {
                anim.SetTrigger("hurt");
                SoundFXManager.instance.PlaySoundFXClip(hurtSound, transform, .2f);
                StartCoroutine(DamageFlash());
            } 
            // else if (health <= 0)
            // {
            //     isDead = true;
            //     anim.SetTrigger("death");
            //     SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, .3f);
            //     Destroy(transform.parent.gameObject, 0.5f);
            //     randomHeart();
            // }
        }
        else if(other.tag == "Player")
        {
            script.takeDamage(damage);
        }
    }
    IEnumerator DamageFlash()
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
