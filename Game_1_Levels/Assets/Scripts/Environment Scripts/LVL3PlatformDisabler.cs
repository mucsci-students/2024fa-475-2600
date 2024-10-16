using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LVL3PlatformDisabler : MonoBehaviour
{
    //private TilemapCollider2D platforms;
    public float waitTime = 1;

    void Start()
    {
        //platforms = GetComponent<TilemapCollider2D>();
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //platforms.enabled = false;
            foreach(BoxCollider2D c in GetComponents<BoxCollider2D>()) 
            {
                c.enabled = false;
            }
            StartCoroutine(DisableCollider());
        }
    }
   IEnumerator DisableCollider () 
   {
        yield return new WaitForSeconds (waitTime);
        foreach(BoxCollider2D c in GetComponents<BoxCollider2D>()) 
        {
            c.enabled = true;
        }
        //platforms.enabled = true;
   }
}
