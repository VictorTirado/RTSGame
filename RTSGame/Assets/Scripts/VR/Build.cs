﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Build : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; 

    public SteamVR_Action_Boolean ShowCanvas;
    public SteamVR_Action_Boolean GrabAction;
    public GameObject collidingObject = null; 

    public bool HasToShow = false;
    public bool HasToBuild = false;
    public GameObject canvas = null;

    public GameObject camera_eyes = null;

    public GameObject building;

    public bool set_building = false;
    public GameObject build = null;
    public GameObject FinalBuilding = null;
    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("VRController").GetComponent<asd>().peasant == false)
        {
            if (GetBuild()==true)
                ViewCanvas();

            if (collidingObject != null)
                Building();
            if (GetGrab2() == true && this.GetComponent<PreviewBuilding>().ShowQuad == true && this.GetComponent<PreviewBuilding>().cube.GetComponent<Buildable>().isBuildable == true)
                SetBuilding();
     
        }
      
    }


    public bool GetBuild()
    {
        return ShowCanvas.GetStateDown(handType);
    }
    public bool GetGrab()
    {
      
        return GrabAction.GetStateDown(handType);
    }
    public bool GetGrab2()
    {

        return GrabAction.GetStateUp(handType);
    }

    public bool ViewCanvas()
    {
        if(ShowCanvas.GetStateDown(handType) == true)
        {
            HasToShow = !HasToShow;
            if (HasToShow == true)
                Canvas();
            else if (HasToShow == false)
                canvas.SetActive(false);
        }

        
        return ShowCanvas.GetStateDown(handType);
        
    }

    public void Canvas()
    {
        //POSITION
        Ray ray = new Ray(camera_eyes.transform.position, camera_eyes.transform.forward);
        Debug.DrawRay(camera_eyes.transform.position, camera_eyes.transform.forward, Color.red, 10.0f);

        //ROTATION
        Vector3 rotation = ray.GetPoint(0.6f);
        Quaternion final_rot = Quaternion.Euler(camera_eyes.transform.rotation.eulerAngles.x + 90, camera_eyes.transform.rotation.eulerAngles.y, rotation.z);

        canvas.transform.position = ray.GetPoint(0.6f);
        canvas.transform.rotation = final_rot;
        canvas.SetActive(true);
    }

    public void Building()
    {
       
        if (collidingObject.tag=="Building" &&HasToBuild == true)
        {
           
            if(GetGrab())
            {

                ShowPreview();
               
            }
        }
      
    }
   

    private void CheckBuilding(Collider coll)
    {
        collidingObject = coll.gameObject;
    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            HasToBuild = true;
            CheckBuilding(other);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Building")
        //{
        //    HasToBuild = false;


        //}
        if (other.gameObject.tag == "Building") HasToBuild=false;
    }

    public void ShowPreview()
    {
        GameObject loadedObject = Resources.Load("Prefabs/" + collidingObject.name) as GameObject;
       
        build = GameObject.Instantiate(loadedObject, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),loadedObject.transform.rotation);
        this.GetComponent<PreviewBuilding>().objectInHand = build;
        build.transform.localScale = new Vector3(0.04539477f, 0.02854358f, 0.03525941f);   
       
        HasToBuild = false;
        collidingObject = null;
    }


    public void SetBuilding()
    {
        Destroy(this.GetComponent<PreviewBuilding>().cube);
        this.GetComponent<PreviewBuilding>().cube = null;

        FinalBuilding = Instantiate(build, new Vector3(this.GetComponent<PreviewBuilding>().transform.position.x, -0.25f, this.GetComponent<PreviewBuilding>().transform.position.z),build.transform.rotation);
        
        FinalBuilding.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        FinalBuilding.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation ;
   
    }

}