using UnityEngine;

public class MoveTowardsCamera : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    void Update()
    {
        // Get the position of the main camera
        Vector3 cameraPosition = Camera.main.transform.position;

        // Calculate direction from object to camera
        Vector3 directionToCamera = (cameraPosition - transform.position).normalized;

        // Move the object towards the camera
        transform.position += directionToCamera * speed * Time.deltaTime;

        // Optional: Make the object face the camera
        transform.LookAt(cameraPosition);
    }
}

