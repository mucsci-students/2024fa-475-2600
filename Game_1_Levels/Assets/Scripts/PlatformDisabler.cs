using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformDisabler : MonoBehaviour
{
    private TilemapCollider2D platforms;

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
        yield return new WaitForSeconds (1f);
        platforms.enabled = true;
   }
}
