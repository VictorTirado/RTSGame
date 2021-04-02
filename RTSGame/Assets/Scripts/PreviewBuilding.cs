using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PreviewBuilding : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    private GameObject collidingObject; // 1
    public GameObject objectInHand; // 2

    

    // Update is called once per frame
 


    public void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }


    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
        // 4
        objectInHand = null;
    }


    void Update()
    {
        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        if (objectInHand != null)
            ShowPreview();



    }


    public void ShowPreview()
    {
        objectInHand.transform.GetChild(2).gameObject.transform.position.Set(objectInHand.transform.position.x, -380.0f, objectInHand.transform.position.z);
        //objectInHand.transform.GetChild(2).gameObject.transform.position =  Vector3(objectInHand.transform.position.x, 380.0f, objectInHand.transform.position.z);
    }









}
