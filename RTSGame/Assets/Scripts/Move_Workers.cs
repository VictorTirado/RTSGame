using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.AI;

public class Move_Workers : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean MoveWorkers;

    public GameObject camera_eyes = null;
    public LayerMask teleportMask;

    private GameObject laser;
    public GameObject laserPrefab;
    private Vector3 hitPoint;
    private Transform laserTransform;

    private NavMeshAgent agent;

    List<GameObject> villagers_selected;
    // Start is called before the first frame update
    void Start()
    {
        villagers_selected = this.GetComponent<GetPeople2>().people_selected;

        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (villagers_selected.Count > 0)
        {
            RaycastHit hit;
            if (MoveWorkers.GetState(handType))
            {
                if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, Mathf.Infinity, teleportMask))
                {
                    Ray ray;
                    ray = new Ray(camera_eyes.transform.position, camera_eyes.transform.forward);
                    hitPoint = hit.point;
                    ShowLaser(hit);
                }

            }
        }
        if (MoveWorkers.GetStateUp(handType) == true)
        {
            Debug.Log("HOOOOOOOOOOOOOOO");
            for (int i = 0; i < villagers_selected.Count; i++)
            {
                villagers_selected[i].GetComponent<NavMeshAgent>().SetDestination(hitPoint);
                villagers_selected[i].GetComponent<Animator>().SetBool("isShooting", false);
                villagers_selected[i].GetComponent<Animator>().SetBool("isWalking", true);
             
            }
            Destroy(laser);


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
