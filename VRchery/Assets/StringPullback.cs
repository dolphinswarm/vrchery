using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class StringPullback : MonoBehaviour
{
    // Bow Pullback
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public OVRInput.Controller left;
    public OVRInput.Controller right;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance between hands for bow pullback animation
        float distance = Mathf.Max(((OVRInput.GetLocalControllerPosition(left) - OVRInput.GetLocalControllerPosition(right)).magnitude - 0.3f), 0.0f) * 325.0f;
        Debug.Log(distance);

        // Calculate angle between hands
        Quaternion leftHandAngle = OVRInput.GetLocalControllerRotation(left);
        Quaternion rightHandAngle = OVRInput.GetLocalControllerRotation(right);

        // If right bumper pressed, apply pullback animation
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, right))
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, distance);
        }
        
        // Else, set back to 0
        else
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        }
        
    }
}
