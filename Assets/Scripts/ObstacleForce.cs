using UnityEngine;

public class ObstacleForce : MonoBehaviour
{
    /// <summary>
    /// The multiplier to adjust the strength of the applied force
    /// </summary>
    public float forceMultiplier = 10f;

    /// <summary>
    /// Set a non-zero value to add a small delay before applying force (in seconds)
    /// </summary>
    public float forceDelay = 0f;

    /// <summary>
    /// When the object collides with another collider
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // Check if the collider belongs to the player (ensure your player GameObject has the "Player" tag)
        if ( ! collision.gameObject.CompareTag("Player")) return;

        // Calculate the direction to push the obstacle: from the collision point to the obstacle's center
        var forceDirection = (transform.position - collision.contacts[0].point).normalized;

        // delay the force application
        if (forceDelay > 0f)
        {
            Invoke(nameof(ApplyForce)
                 , forceDelay);
        }
        else
        {
            ApplyForce(forceDirection);
        }
    }

    /// <summary>
    /// Applies an impulse force to the obstacle's Rigidbody
    /// </summary>
    /// <remarks>forceDirection is an optional parameter to experiment with forceDirection vs transform.forward </remarks>
    private void ApplyForce(Vector3? forceDirection = null)
    {
        var component = GetComponent<Rigidbody>();
        if (component == null) return;

        // Use the provided forceDirection if it's not null; otherwise, use transform.forward
        var appliedForce = forceDirection ?? transform.forward;
        component.AddForce(appliedForce * forceMultiplier, ForceMode.Impulse);
    }
}