using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1WinScreen : MonoBehaviour
{
    public SlimeMovement script;
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
