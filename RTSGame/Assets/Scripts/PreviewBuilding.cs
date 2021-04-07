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
    public GameObject cube;

    public bool ShowQuad = false;

    // Update is called once per frame
 


    public void GrabObject()
    {
        objectInHand = this.GetComponent<Build>().build;
        // 1
        //objectInHand = collidingObject;
        //collidingObject = null;
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
            if (objectInHand != null)
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

        if (cube != null && ShowQuad == true )
            UpdateQuadPos();

    }


    public void ShowPreview()
    {
      
        foreach (Transform child in objectInHand.transform)
        {
            //Debug.Log(child.name);
            if (child.tag == "Preview" && ShowQuad == false)
            {
              
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Buildable>();
                cube.transform.position = new Vector3(objectInHand.transform.position.x, 0.0f, objectInHand.transform.position.z);
                cube.transform.localScale = new Vector3(child.localScale.x, child.localScale.y, child.localScale.z);
                ShowQuad = true;
            }
        }
     
    }

    public void UpdateQuadPos()
    {
        
        cube.transform.position = new Vector3(objectInHand.transform.position.x, 0.0f, objectInHand.transform.position.z);
       
    }


 








}
