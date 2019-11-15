using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public int CheckPoints(Vector3 position)
    {
        return (35 - Mathf.RoundToInt((gameObject.transform.position - position).magnitude * 50.0f));
    }
}
