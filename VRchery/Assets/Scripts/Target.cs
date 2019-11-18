using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    // Calculate the points
    public int CheckPoints(Collision collision)
    {
        // Find average contact points
        Vector3 position = new Vector3();
        foreach (ContactPoint contactPoint in collision.contacts)
        {
            position += contactPoint.point;
        }
        position /= collision.contactCount;

        // Return position
        return (25 - Mathf.RoundToInt((gameObject.transform.position - position).magnitude * 50.0f));
    }
}
