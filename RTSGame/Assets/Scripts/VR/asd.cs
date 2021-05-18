using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class asd : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean ChangeViewAction; // 3

    public bool peasant = false;
    public bool InGround = false;
    public bool InAir = true;

    // Update is called once per frame
    void Update()
    {
       
        if(ChangeView())
        {
           
            Change();
        }
    

    }
    public bool ChangeView()
    {
        return ChangeViewAction.GetStateDown(handType);
    }

    public bool Change()
    {

        if (peasant == true)
        {
            GameObject.Find("Controller (left)").GetComponent<ControllerGrabObject>().enabled = false;
            GameObject.Find("Controller (right)").GetComponent<ControllerGrabObject>().enabled = false;
            //this.gameObject.GetComponent<VRController>().PlayerIsInFloor = false;
            this.gameObject.GetComponent<VRController>().PlayerInAir();
            peasant = false;
            
        }
        else if (peasant == false)
        {
            GameObject.Find("[CameraRig]").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GameObject.Find("Controller (left)").GetComponent<ControllerGrabObject>().enabled = true;
            GameObject.Find("Controller (right)").GetComponent<ControllerGrabObject>().enabled = true;
            this.gameObject.GetComponent<VRController>().PlayerInFloor();
           
            //GameObject.Find("Canvas").SetActive(false);
            peasant = true;

        }

        return peasant;
    }

}
