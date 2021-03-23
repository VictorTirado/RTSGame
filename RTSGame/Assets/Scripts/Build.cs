using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Build : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; 

    public SteamVR_Action_Boolean ShowCanvas; 
    public GameObject collidingObject = null; 

    public bool HasToShow = false;
    public bool HasToBuild = false;
    public GameObject canvas = null;

    public GameObject camera_eyes = null;
   
    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("VRController").GetComponent<asd>().peasant == false)
        {
            if (GetBuild()==true)
                ViewCanvas();
        
           
           // Building();
        }
        
    }

    // EMPUÑADURA PULSADA
    public bool GetBuild()
    {
        return ShowCanvas.GetStateDown(handType);
    }
    // MUESTRA CANVAS
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
    //SETEA CANVAS EN LA POSICION QUE TOCA
    public void Canvas()
    {
        
       
        //POSITION
        Ray ray = new Ray(camera_eyes.transform.position, camera_eyes.transform.forward);
        Debug.DrawRay(camera_eyes.transform.position, camera_eyes.transform.forward, Color.red, 10.0f);

        //ROTATION
        //Vector3 rot = GameObject.Find("Camera (eye)").transform.rotation.eulerAngles;
        //rot = new Vector3(rot.x, rot.y, rot.z);
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
            Debug.Log(collidingObject.name);
            //GameObject build = Instantiate(collidingObject, new Vector3(this.transform.position.x, 0.0f, this.transform.position.z), Quaternion.identity);  
           // Vector3 pos = new Vector3(this.transform.position.x, GameObject.Find("TB_Env_Tile_Grass_A").transform.position.y, this.transform.position.z);
          //  collidingObject.transform.position = pos;
            //build.transform.localScale = new Vector3(1, 1, 1);
            HasToBuild = false;
            collidingObject = null;
        }
      
    }
   

    private void CheckBuilding(Collider coll)
    {
        collidingObject = coll.gameObject;
        Building();
       // Debug.Log(collidingObject.gameObject.name);
        
    }

    public void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            CheckBuilding(other);
            HasToBuild = true;
        }
    }
}
