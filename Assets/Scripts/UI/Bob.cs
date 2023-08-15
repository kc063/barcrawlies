using UnityEngine;

public class BobbingObject : MonoBehaviour
{
    public float bobSpeed = 1.0f;       // Speed of bobbing
    public float bobHeight = 0.5f;      // Height of the bob
    private Vector3 initialPosition;    // Initial position of the object

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate new position based on sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        // Apply new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}