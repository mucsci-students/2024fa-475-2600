using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] public float jumpHeight;
    private float timer = 0f;
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5 && anim.GetBool("isRunning"))
        {
            timer = 0;
            anim.SetTrigger("jump");
            StartCoroutine(goIdle());
        }
    }
    IEnumerator goIdle() 
    {
        yield return new WaitForSeconds (1f);
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
    }
}
