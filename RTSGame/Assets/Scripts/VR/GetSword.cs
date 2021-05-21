using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GetSword : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sword;

    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean GrabAction; // 3
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DAVINKIIIIIIIII");
    }
}
