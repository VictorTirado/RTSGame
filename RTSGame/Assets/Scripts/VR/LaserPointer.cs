using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;
    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4
                              // 1
    public Transform cameraRigTransform;
    // 2
    public GameObject teleportReticlePrefab;
    // 3
    private GameObject reticle;
    // 4
    private Transform teleportReticleTransform;
    // 5
    public Transform headTransform;
    // 6
    public Vector3 teleportReticleOffset;
    // 7
    public LayerMask teleportMask;
    // 8
    private bool shouldTeleport;

    public bool PlayerIsInAir = false;


    private void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

        // 1
        reticle = Instantiate(teleportReticlePrefab);
        // 2
        teleportReticleTransform = reticle.transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("VRController").GetComponent<asd>().peasant == false)
        {
            if (PlayerIsInAir == false)
            {
               
                Flying();
            }
           
            if (teleportAction.GetState(handType))
            {
                RaycastHit hit;

                // 2
                if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
                {
                    hitPoint = hit.point;
                    ShowLaser(hit);
                    // 1
                    reticle.SetActive(true);
                    // 2
                    teleportReticleTransform.position = hitPoint + teleportReticleOffset;

                    // 3
                    shouldTeleport = true;

                }
            }
            else // 3
            {
                laser.SetActive(false);
                reticle.SetActive(false);

            }
            if (teleportAction.GetStateUp(handType) && shouldTeleport)
            {
                Teleport();
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
    private void Teleport()
    {
       
        shouldTeleport = false;
        
        reticle.SetActive(false);
        
        Vector3 difference = cameraRigTransform.position - headTransform.position;
      
        difference.y = 0;
   
        cameraRigTransform.parent.position = new Vector3(hitPoint.x, 15.0f, hitPoint.z);
    }

    private void Flying()
    {
       
        PlayerIsInAir = true;
       
        Vector3 pos = new Vector3(this.transform.position.x, 10.0f, this.transform.position.z);
        GameObject.Find("VRController").transform.position = new Vector3(GameObject.Find("VRController").transform.position.x,15.0f, GameObject.Find("VRController").transform.position.z);
        GameObject.Find("VRController").GetComponent<VRController>().PlayerIsInFloor = false;
    }

}
