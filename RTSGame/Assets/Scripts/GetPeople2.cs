using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR;

public class GetPeople2 : MonoBehaviour
{
    public SteamVR_Input_Sources handType;

    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;

    public GameObject laserPrefab; 
    public GameObject villager_selected = null;
    public GameObject camera_eyes = null;
    private GameObject laser;

    private Transform laserTransform; 

    private Vector3 hitPoint;
    public Vector3 teleportReticleOffset;

    public bool set_people = false;
    bool leaved = false;

    public LayerMask teleportMask;
    public LayerMask teleport2Mask;

   





    private void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("VRController").GetComponent<asd>().peasant == false)
        {
            Debug.Log(teleportAction.GetStateUp(handType));
            RaycastHit hit;
            if (teleportAction.GetState(handType) && set_people == false)
            {

                if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask))
                {
                  
                    if (hit.transform.gameObject.tag == "People" && hit.transform.GetComponent<CaughtPeople>().is_caught == false && set_people ==false)
                    {
                        Ray ray = new Ray(camera_eyes.transform.position, camera_eyes.transform.forward);
                        Debug.DrawRay(camera_eyes.transform.position, camera_eyes.transform.forward, Color.red, 10.0f);

                        hit.transform.position = ray.GetPoint(0.6f);
                       
                     

                        villager_selected = hit.transform.gameObject;
                        villager_selected.GetComponent<NavMeshAgent>().enabled = false;
                       
                        hit.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        hit.transform.GetComponent<CaughtPeople>().is_caught = true;
                        hit.transform.GetComponent<CaughtPeople>().ShowWorks();
                    }



                   
                    hitPoint = hit.point;
                    ShowLaser(hit);

                }
            }
            else if (teleportAction.GetState(handType) &&set_people == true)
            {
               
                if(Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, Mathf.Infinity, teleport2Mask))
                {
                    villager_selected.transform.position = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
                    villager_selected.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                  
                    if (villager_selected.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
                    {
                        villager_selected.GetComponent<Animator>().SetBool("isWalking", true);
                       
                        villager_selected.GetComponent<None_work>().LeaveResources = false;
                        villager_selected.GetComponent<None_work>().HasResources = false;
                        villager_selected.GetComponent<None_work>().InPosition = false;
                        villager_selected.GetComponent<None_work>().SetPosition = false;
                        
                    }
                   
                    hitPoint = hit.point;
                    ShowLaser(hit);
                    leaved = true;  
                }
            }
            else if (teleportAction.GetStateUp(handType) == true && villager_selected!=null && leaved == true)
            {
               
                villager_selected.GetComponent<NavMeshAgent>().enabled = true;
                villager_selected.GetComponent<CaughtPeople>().is_caught = false;
                villager_selected = null;
                set_people = false;
                leaved = false;

            }
            else 
            {
                laser.SetActive(false);
             }
          

        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }


  
  
}
