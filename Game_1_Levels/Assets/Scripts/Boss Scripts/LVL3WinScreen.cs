using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3WinScreen : MonoBehaviour
{
    public KnightPatrol script;
    public WinScript winScript;
    private float timer = 0f;

    void Update()
    {
        if (script.health <= 0)
        {
            timer += Time.deltaTime;
            if (timer >= 4)
            {
                winScript.Win();
            }
        }
    }
}
