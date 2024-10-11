using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlimeAnimation : MonoBehaviour
{
    public Manager script;
    private float timer = 0f;
    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] Vector2 jumpDistance;
    [SerializeField] public float health;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            anim.SetTrigger("jump");
            body.velocity = jumpDistance;
        }

    }
}
