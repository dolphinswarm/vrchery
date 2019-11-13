using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class StringPullback : MonoBehaviour
{
    // ============================================================================ Variables
    // Public variables
    [Header("Oculus")]
    public OVRInput.Controller left;
    public GameObject leftHand;
    public OVRInput.Controller right;
    public GameObject rightHand;

    [Header("Bow")]
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject pullbackController;
    public GameObject arrow;

    // Private variables
    private bool release = false;
    private GameObject currentArrow;

    // ============================================================================ Private methods
    // Start is called before the first frame update
    void Start()
    {
        currentArrow = null;
        //skinnedMeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
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
        bool validPull = (rightHandPosition - pullbackController.transform.position).magnitude <= 0.08;

        // If right bumper pressed, apply pullback
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, right) && validPull)
        {
            // Set arrow in bow if not present
            if (release == false)
            {
                release = true;
                currentArrow = Instantiate(arrow, gameObject.transform);
                currentArrow.transform.localScale = new Vector3(1.0f, 1.5f, 1.0f);
            }

            // Apply pullback animation
            pullbackController.transform.localPosition = new Vector3(0.0f, pullValue, 0.0f);
            currentArrow.transform.localPosition = new Vector3(0.0f, 0.0f, pullValue + 0.5f);
            skinnedMeshRenderer.SetBlendShapeWeight(0, distance);
        }
        
        // Else, set back to 0
        else
        {
            // Check if released. If released, apply arrow shoot
            if (release == true)
            {
                currentArrow.GetComponentInChildren<Arrow>().FireArrow(distance);
                currentArrow = null;
                release = false;
            }

            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
            pullbackController.transform.localPosition = new Vector3(0.0f, -0.366f, 0.0f);
            //currentArrow.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
    }
}
