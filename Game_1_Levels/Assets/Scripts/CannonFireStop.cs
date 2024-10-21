using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonFireStop : MonoBehaviour
{
    public CannonBallTrigger script;

    void OnTriggerEnter2D()
    {
        script.inCollider = false;
        script.anim.SetBool("inRange", false);
        Destroy(script.cannonBall);
        Destroy(gameObject);
    }
}
