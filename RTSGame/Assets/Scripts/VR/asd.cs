using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class asd : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean ChangeViewAction; // 3
    public GameObject swords;

    public bool peasant = false;
    public bool InGround = false;
    public bool InAir = true;

    public GameObject pick;
    public GameObject axe;
    public GameObject sword;
    public GameObject table;

    // Update is called once per frame
 
    void Update()
    {
        if (peasant == true)
        {
            if (GameObject.FindGameObjectWithTag("Commander").gameObject != null)
                GameObject.FindGameObjectWithTag("Commander").gameObject.transform.position = this.transform.position;


        }
        if (ChangeView())
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
            pick.transform.position = new Vector3(table.transform.position.x, table.transform.position.y +1.6f, table.transform.position.z);
            pick.GetComponent<Rigidbody>().velocity = Vector3.zero;
            pick.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            axe.transform.position = new Vector3(table.transform.position.x - 1.5f, table.transform.position.y + 1.6f, table.transform.position.z);
            axe.GetComponent<Rigidbody>().velocity = Vector3.zero;
            axe.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //sword.transform.position = new Vector3(0.19f, 1.061047f, -0.1173649f);
            sword.GetComponent<Rigidbody>().velocity = Vector3.zero;
            sword.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //pick.transform.position = new Vector3(-0.747f, 0.27f, 1.47f);
            //axe.transform.position = new Vector3(-1.6483f, 0.33f, 1.38f);
            //sword.transform.position = new Vector3(0.19f, 1.06f, -0.11f);
            swords.SetActive(false);
            peasant = false;
            
        }
        else if (peasant == false)
        {
            GameObject.Find("[CameraRig]").transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GameObject.Find("Controller (left)").GetComponent<ControllerGrabObject>().enabled = true;
            GameObject.Find("Controller (right)").GetComponent<ControllerGrabObject>().enabled = true;
            this.gameObject.GetComponent<VRController>().PlayerInFloor();
           
            swords.SetActive(true);
            //GameObject.Find("Canvas").SetActive(false);
            peasant = true;

        }

        return peasant;
    }

}
