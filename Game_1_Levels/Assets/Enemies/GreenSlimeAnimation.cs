using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeAnimation : MonoBehaviour
{
    public Manager script;
    private float timer = 0f;
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] public float jumpHeight;
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4 && anim.GetBool("isRunning"))
        {
            timer = 0;
            anim.SetTrigger("jump");
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
        }
    }
}
