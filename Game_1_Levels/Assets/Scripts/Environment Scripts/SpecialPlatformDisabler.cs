using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatformDisabler : MonoBehaviour
{
    public float waitTime = 1;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(BoxCollider2D c in GetComponents<BoxCollider2D> ()) 
            {
                c.enabled = false;
            }
            StartCoroutine(DisableCollider());
        }
    }
    IEnumerator DisableCollider() 
    {
        yield return new WaitForSeconds (1f);
        foreach(BoxCollider2D c in GetComponents<BoxCollider2D>()) 
        {
            c.enabled = true;
        }
    }
}
