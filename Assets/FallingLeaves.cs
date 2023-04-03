using UnityEngine;

public class FallingLeaves : MonoBehaviour
{
    public float fallSpeed = 10f; // The speed at which the leaf falls
    public float driftSpeed = 0.5f; // The speed at which the leaf drifts to the side
    public float driftRange = 2f; // The maximum distance the leaf can drift from side to side
    private Vector3 startPosition; // The initial position of the leaf

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the leaf downwards
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);

        // Move the leaf to the side in a random pattern
        float xDrift = Mathf.Sin(Time.time * driftSpeed) * driftRange;
        transform.position = new Vector3(startPosition.x + xDrift, transform.position.y, transform.position.z);

        // Destroy the leaf object when it goes off the screen
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}


