using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformDisabler : MonoBehaviour
{
    private TilemapCollider2D platforms;
    public float waitTime;

    void Start()
    {
        platforms = GetComponent<TilemapCollider2D>();
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            platforms.enabled = false;
            StartCoroutine(DisableCollider());
        }
    }
   IEnumerator DisableCollider () 
   {
        yield return new WaitForSeconds (waitTime);
        platforms.enabled = true;
   }
}
