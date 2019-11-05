using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class StringPullback : MonoBehaviour
{
    // Bow Pullback
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public OVRInput.Controller left;
    public GameObject leftHand;
    public OVRInput.Controller right;
    public GameObject rightHand;
    public GameObject pullbackController;

    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate distance between hands for bow pullback animation
        float distance = Mathf.Max((OVRInput.GetLocalControllerPosition(left) - OVRInput.GetLocalControllerPosition(right)).magnitude - 0.3f, 0.0f) * 325.0f;
        //Debug.Log("Distance between hands: " + distance);

        // Find hand angles
        Vector3 leftHandAngle = OVRInput.GetLocalControllerRotation(left).eulerAngles;
        Vector3 rightHandAngle = OVRInput.GetLocalControllerRotation(right).eulerAngles;
        //Debug.Log(leftHandAngle);
        //Debug.Log(rightHandAngle);
        //Debug.Log(Vector3.Dot(leftHandAngle.normalized, rightHandAngle.normalized));


        // Calculate position of pullbackController
        Vector3 position = pullbackController.transform.localPosition;
        float pullValue = -0.366f - (distance / 242.0f);
        //Debug.Log("Pullback Value: " + pullValue);

        // Check positions of hand and cube
        Vector3 rightHandPosition = new Vector3(rightHand.transform.position.x, rightHand.transform.position.y - 0.035f, rightHand.transform.position.z);
        bool validPull = (rightHandPosition - pullbackController.transform.position).magnitude <= 0.07;

        // If right bumper pressed, apply pullback animation
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, right) && validPull)
        {
            pullbackController.transform.localPosition = new Vector3(0.0f, pullValue, 0.0f);
            skinnedMeshRenderer.SetBlendShapeWeight(0, distance);
        }
        
        // Else, set back to 0
        else
        {
            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            pullbackController.transform.localPosition = new Vector3(0.0f, -0.366f, 0.0f);
        }
        
    }
}
