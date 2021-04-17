using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PreviewBuilding : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
 
    public GameObject objectInHand;
    public GameObject cube;

    public bool ShowQuad = false;

    public void GrabObject()
    {
        objectInHand = this.GetComponent<Build>().build;
      
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
      
        if (GetComponent<FixedJoint>())
        {
          
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
          
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();

        }
       
        objectInHand = null;
        Destroy(this.GetComponent<Build>().build);
        this.GetComponent<Build>().build = null;
        ShowQuad = false;
    }


    void Update()
    {
       
     
        if (grabAction.GetLastStateDown(handType))
        {
            if (objectInHand != null)
            {
                GrabObject();
            }
        }

       
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
         
            if (child.tag == "Preview" && ShowQuad == false)
            {
              
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Buildable>();
                cube.name = "PEPE";
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
