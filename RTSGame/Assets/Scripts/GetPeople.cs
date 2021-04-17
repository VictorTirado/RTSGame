using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.AI;

public class GetPeople : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean CaughtPeople;
    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
                              // 1

    public bool set_people = false;
    public GameObject teleportReticlePrefab;
    // 3
    private GameObject reticle;
    // 4
    private Transform teleportReticleTransform;
    // 5

    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    // 8

    public GameObject villager_selected = null;



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
            
           
            if (CaughtPeople.GetState(handType))
            {
               
                RaycastHit hit;

          
                if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.tag == "People" && hit.transform.GetComponent<CaughtPeople>().is_caught == false)
                    {
                        villager_selected = hit.transform.gameObject;
                        villager_selected.GetComponent<NavMeshAgent>().enabled = false;
                        hit.transform.position = this.transform.position;
                        hit.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        hit.transform.GetComponent<CaughtPeople>().is_caught = true;
                    }
                    hitPoint = hit.point;
                    ShowLaser(hit);


                    //if (set_people == true)
                    //{
                    //    villager_selected.transform.position = hitPoint;
                    //    if (CaughtPeople.GetStateUp(handType))
                    //    {
                    //        villager_selected.transform.position = hitPoint;
                    //        villager_selected.GetComponent<NavMeshAgent>().enabled = true;
                    //        villager_selected = null;
                    //    }
                           

                    //}

                }
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
   
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }




}
