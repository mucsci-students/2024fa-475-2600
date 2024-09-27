using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeCheck : MonoBehaviour
{
    
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;

    private void SlopeCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, -Vector2.up, 10f, layerMask);
        if (Hit2D != false)
        {
            Vector2 temp = playerFeet.position;
            temp.y = Hit2D.point.y;
            playerFeet.position = temp;
        }
    }
    void Update()
    {
        SlopeCheckMethod();
    }
}
