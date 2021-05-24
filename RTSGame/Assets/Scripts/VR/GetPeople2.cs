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
    public SteamVR_Action_Boolean SelectAction;


    public GameObject laserPrefab; 
    public GameObject villager_selected = null;
    public GameObject camera_eyes = null;
    private GameObject laser;

    private Transform laserTransform; 

    private Vector3 hitPoint;
    public Vector3 teleportReticleOffset;

    public bool set_people = false;
    bool leaved = false;
    public bool selected = false;

    public LayerMask teleportMask;
    public LayerMask teleport2Mask;

    public Material material;
    public Material material2;

    public List<GameObject> people_selected;

    Ray ray;
    RaycastHit hit2;
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
             RaycastHit hit;
            Debug.Log(teleportAction.GetStateUp(handType));
          
            if (teleportAction.GetState(handType) && set_people == false)
            {
               

                if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask))
                {

                    if (hit.transform.gameObject.tag == "People" && hit.transform.GetComponent<CaughtPeople>().is_caught == false && set_people == false)
                    {
                        ray = new Ray(camera_eyes.transform.position, camera_eyes.transform.forward);
                        //Debug.DrawRay(camera_eyes.transform.position, camera_eyes.transform.forward, Color.red, 10.0f);

                       villager_selected = hit.transform.gameObject;
                        hit2 = hit;
                        selected = true;

                        if (SelectAction.GetStateDown(handType))
                        {
                            if (villager_selected.transform.GetChild(14).gameObject.active == false)
                            {
                                people_selected.Add(villager_selected);
                                villager_selected.transform.GetChild(14).gameObject.SetActive(true);
                            }
                            else if(villager_selected.transform.GetChild(14).gameObject.active == true)
                            {
                                people_selected.Remove(villager_selected);
                                villager_selected.transform.GetChild(14).gameObject.SetActive(false);
                            }
                        }
                    }
                    else if (hit.transform.gameObject.tag != "People")
                    {
                        selected = false;
                    }



                   
                    hitPoint = hit.point;
                    ShowLaser(hit);

                }
            }
            else if (teleportAction.GetStateUp(handType) == true && selected == true)
            {
                hit2.transform.position = ray.GetPoint(0.6f);
                villager_selected = hit2.transform.gameObject;
                villager_selected.GetComponent<NavMeshAgent>().enabled = false;
                //var lookPos = GameObject.Find("VRController").transform.position - villager_selected.transform.position;
                //lookPos.y = 0;
                //var rotation = Quaternion.LookRotation(lookPos);

                villager_selected.transform.rotation = Quaternion.Euler(GameObject.Find("Camera (eye)").transform.rotation.x, GameObject.Find("Camera (eye)").transform.rotation.y - 180, GameObject.Find("Camera (eye)").transform.rotation.z);
                //villager_selected.transform.rotation = Quaternion.Slerp(villager_selected.transform.rotation, rotation, Time.deltaTime * 1);
               
                hit2.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                hit2.transform.GetComponent<CaughtPeople>().is_caught = true;
                hit2.transform.GetComponent<CaughtPeople>().ShowWorks();


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
                    selected = false;
                }
            }
            else if (teleportAction.GetStateUp(handType) == true && villager_selected!=null && leaved == true)
            {
               
                villager_selected.GetComponent<NavMeshAgent>().enabled = true;
                villager_selected.GetComponent<CaughtPeople>().is_caught = false;
                villager_selected = null;
                set_people = false;
                leaved = false;
                selected = false;
                //GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().ResetWorkers();
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
        if (selected == true)
        {
            laser.GetComponent<Renderer>().material = material;
        }
        if (selected == false)
        {
            laser.GetComponent<Renderer>().material = material2;
        }
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, hit.distance);
    }


  
  
}
