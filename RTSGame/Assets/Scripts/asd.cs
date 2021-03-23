using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class asd : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean ChangeViewAction; // 3

    public bool peasant = false;
    public bool InGround = false;
    public bool InAir = true;

    // Update is called once per frame
    void Update()
    {
       
        if(ChangeView())
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
            peasant = false;
            Debug.Log("Player mode");
        }
        else if (peasant == false)
        {
            peasant = true;

            Debug.Log("God mode");
        }

        return peasant;
    }

}
