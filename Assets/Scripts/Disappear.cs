using UnityEngine;

public class ObjectDisappear : MonoBehaviour
{
    public float speed = 5f;          // Speed at which the object moves
    public float disappearChance = 0.3f; // Chance (30%) for the object to disappear randomly

    private void Start()
    {
        // Randomly decide if this object should disappear on its way
        if (Random.value < disappearChance)
        {
            // Destroy this object after a random delay (between 1-3 seconds)
            Destroy(gameObject, Random.Range(1f, 3f));
        }
    }

    private void Update()
    {
        // Move the object toward the camera or forward in Z direction
        transform.position += Vector3.forward * speed * Time.deltaTime;

        // Optional: Add logic to destroy the object when it gets too close to the camera
        if (transform.position.z > Camera.main.transform.position.z + 5f)
        {
            Destroy(gameObject);
        }
    }
}
