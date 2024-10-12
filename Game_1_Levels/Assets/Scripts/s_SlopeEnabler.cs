using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeEnabler : MonoBehaviour
{
    private GameObject player;
    private string script;

    void Start()
    {
        script = "SlopeCheck";
        player = GameObject.FindWithTag("Player");
        (player.GetComponent(script) as MonoBehaviour).enabled = false;
        //player.GetComponent<SlopeCheck>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(EdgeCollider2D c in GetComponents<EdgeCollider2D> ()) 
            {
                c.enabled = false;
            }
            StartCoroutine(DisableCollider());
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if(other.tag=="Player")
        {
            (player.GetComponent(script) as MonoBehaviour).enabled = true;
            //print("Script is enabled");
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if(other.tag=="Player")
        {
            (player.GetComponent(script) as MonoBehaviour).enabled = false;
            //print("Script is disabled");
        }
    }

    IEnumerator DisableCollider() 
    {
        yield return new WaitForSeconds (1f);
        foreach(EdgeCollider2D c in GetComponents<EdgeCollider2D>()) 
        {
            c.enabled = true;
        }
    }
}
