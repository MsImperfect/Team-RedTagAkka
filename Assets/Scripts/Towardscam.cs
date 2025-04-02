using UnityEngine;

public class MoveTowardsCameraLockRotation : MonoBehaviour
{
    public Camera mainCamera; // Assign your main camera in the Inspector
    public float moveSpeed = 5f; // Speed at which the object moves towards the camera

    private Quaternion initialRotation; // Store the initial rotation of the object

    private void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogError("No camera assigned to the script.");
            return;
        }

        // Store the object's initial rotation
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Lock rotation to its initial value
        transform.rotation = initialRotation;

        // Move towards the camera
        Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
        transform.position += directionToCamera * moveSpeed * Time.deltaTime;
    }
}

