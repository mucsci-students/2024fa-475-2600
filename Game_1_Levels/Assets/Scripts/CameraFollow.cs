using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	Vector3 offset;

	void Start()
	{
		//Record the initial position offset
		offset = transform.position - target.position;
	}

	//Late update runs after all of the normal updates
	void LateUpdate()
	{
		//Update position to follow target while maintaining the offset
		transform.position = target.position + offset;
	}
}
