using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Public variables
    [Header("Arrow Physics")]
    public Rigidbody rigidBody;

    // Private variables
    private bool isStopped = true;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            Vector3 forward = transform.up;
            //transform.position += (forward * 0.05f);
            //transform.Rotate(transform.rotation.x - 1.0f, transform.rotation.y, transform.rotation.z, Space.World);
        }
    }

    void FixedUpdate()
    {
        // Check if stopped
        if (isStopped) return;

        // Apply rotation
        rigidBody.rotation = Quaternion.LookRotation(rigidBody.velocity); // FIX FIRE ISSUE!!
        //rigidBody.MoveRotation(Quaternion.LookRotation(rigidBody.velocity, transform.forward));

    }

    // Stop movement on contact
    void Stop()
    {
        // Update movement variables
        isStopped = true;
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
    }

    // Method for firing an arrow
    public void FireArrow(float distance)
    {
        // Update movement variables
        isStopped = false;
        transform.parent = null;
        //rigidBody.isKinematic = false;
        //rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
        rigidBody.useGravity = true;

        // Apply a force
        rigidBody.AddForce(transform.forward * (speed * (distance / 5.0f)));
    }
}
