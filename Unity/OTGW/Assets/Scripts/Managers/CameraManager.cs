using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public Transform FollowingTransform;
    
	public float SmoothSpeed = 0.125f;

	void LateUpdate()
	{
		var rawPosition = new Vector3(FollowingTransform.position.x, FollowingTransform.position.y, transform.position.z);
		var smoothPosition = Vector3.Lerp(transform.position, rawPosition, SmoothSpeed);

		transform.position = smoothPosition;
	}
}
