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
    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
                              // 1
   

    public bool set_people = false;
    public GameObject villager_selected = null;
    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    public LayerMask teleport2Mask;

    bool leaved = false;
    // 8




    private void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
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
                        villager_selected = hit.transform.gameObject;
                        villager_selected.GetComponent<NavMeshAgent>().enabled = false;
                        hit.transform.position = this.transform.position;
                        hit.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        hit.transform.GetComponent<CaughtPeople>().is_caught = true;
                        hit.transform.GetComponent<CaughtPeople>().ShowWorks();
                    }



                    Debug.Log("HIIIII");
                    hitPoint = hit.point;
                    ShowLaser(hit);

                }
            }
            else if (teleportAction.GetState(handType) &&set_people == true)
            {
                //Debug.Log(teleportAction.GetState(handType));
                if(Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, Mathf.Infinity, teleport2Mask))
                {
                    villager_selected.transform.position = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
                    villager_selected.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    villager_selected.GetComponent<CaughtPeople>().is_caught = false;
                    if (villager_selected.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
                    {
                        villager_selected.GetComponent<Animator>().SetBool("isWalking", true);
                       
                        villager_selected.GetComponent<None_work>().LeaveResources = false;
                        villager_selected.GetComponent<None_work>().HasResources = false;
                        villager_selected.GetComponent<None_work>().InPosition = false;
                        villager_selected.GetComponent<None_work>().SetPosition = false;
                        
                    }
                    //villager_selected.GetComponent<None_work>().cm.m_Animator.SetBool("IsCaught", false);
                    hitPoint = hit.point;
                    ShowLaser(hit);
                    leaved = true;
                    
                    
                }
                //if (teleportAction.GetStateDown(handType))
                //{
                //    villager_selected.transform.position = new Vector3(hitPoint.x, hitPoint.y + 2, hitPoint.z);
                //    villager_selected.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                //}




               


            }
            else if (teleportAction.GetStateUp(handType) == true && villager_selected!=null && leaved == true)
            {
                Debug.Log("GATA LA POLLA");
                villager_selected.GetComponent<NavMeshAgent>().enabled = true;
                villager_selected.GetComponent<CaughtPeople>().is_caught = false;
                villager_selected = null;
                set_people = false;
                leaved = false;

            }
                else // 3
            {
                
                //villager_selected.GetComponent<NavMeshAgent>().enabled = true;
                //villager_selected = null;
                //set_people = false;
                laser.SetActive(false);
            

            }
          

        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }


 
}
