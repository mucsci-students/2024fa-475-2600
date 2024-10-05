using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBounce : MonoBehaviour
{

[SerializeField]
float speed = 5f;

[SerializeField]
float height = 0.5f;

Vector3 pos;

private void Start()
{
pos = transform.position;
}
void Update()
{

//calculate what the new Y position will be
float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
//set the object’s Y to the new calculated Y
transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
}
}