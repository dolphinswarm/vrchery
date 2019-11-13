using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // ============================================================================ Variables
    // Public variables
    [Header("Arrow Physics")]
    public Rigidbody rigidBody;

    // Private variables
    private bool isStopped = true;
    private float speed = 5.0f;

    // ============================================================================ Public methods
    // Method for firing an arrow
    public void FireArrow(float distance)
    {
        // Update movement variables
        isStopped = false;
        transform.parent = null;
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;

        // Apply a force
        rigidBody.AddForce(transform.forward * (speed * (distance / 5.0f)));
    }

    // ============================================================================ Private methods
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    // Physics update
    void FixedUpdate()
    {
        // Check if stopped
        if (isStopped) return;

        // Apply rotation
        rigidBody.MoveRotation(Quaternion.LookRotation(rigidBody.velocity, transform.up));
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered");
        Stop();
    }

    // Stop movement on contact
    private void Stop()
    {
        // Update movement variables
        isStopped = true;
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
    }
}
