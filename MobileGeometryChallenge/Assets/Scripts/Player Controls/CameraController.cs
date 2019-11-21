using UnityEngine;

/// <summary> This script allows to follow the player during the game. </summary>
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    [Range(0.01f,1.0f)]
    public float smooth = 0.5f;

	void Start ()
    {
        cameraOffset = transform.position - playerTransform.position;
	}
	
	void LateUpdate ()
    {
        Vector3 newPosition = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smooth);
	}
}
