using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //if (other.CompareTag("ovr_hand")) return;
        Debug.Log("Entered");
    }
}
