using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_S_SlopeEnabler : MonoBehaviour
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

    void OnTriggerStay2D (Collider2D other)
    {
        (player.GetComponent(script) as MonoBehaviour).enabled = true;
        //print("Script is enabled");
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        (player.GetComponent(script) as MonoBehaviour).enabled = false;
        //print("Script is disabled");
    }
}

