using UnityEngine;

public class RespawnOnFall : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [Tooltip("If the object falls below this Y value, it will respawn.")]
    public float respawnYThreshold = 0.8f;

    private Rigidbody rb;

    void Start()
    {
        // Store the object's original position and rotation (in world space)
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Cache the Rigidbody if it exists
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // If the object falls below the threshold, respawn it
        if (transform.position.y < respawnYThreshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // Reset position and rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // If using physics, reset velocity and angular velocity
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
