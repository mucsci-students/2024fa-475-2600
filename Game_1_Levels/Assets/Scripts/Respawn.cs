using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private GameObject player;
    public Manager script;


    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(script.isDie)
        {
            Die();
        }
    }

    public void Die()
    {
        if(true)
        {
            script.PositionPlayer();
        }
    }
    void OnGUI(){

    }
}
