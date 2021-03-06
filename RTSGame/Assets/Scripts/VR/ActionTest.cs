using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionTest : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean teleportAction; // 2
    public SteamVR_Action_Boolean grabAction; // 3
    public SteamVR_Action_Boolean ChangeViewAction; // 3
    public SteamVR_Action_Boolean BuildAction; // 3
    public SteamVR_Action_Boolean PreviewAction; // 3



    // Update is called once per frame
    void Update()
    {
        if (GetTeleportDown())
        {
            print("Teleport " + handType);
        }

        if (GetGrab())
        {
            print("Grab " + handType);
        }
        if(ChangeView())
        {
            print("Change view " + handType);
        }
        if(GetBuild())
        {
            print("build " + handType);
        }
        if (Preview())
        {
            print("preview " + handType);
        }


    }
    public bool GetTeleportDown() // 1
    {
        return teleportAction.GetStateDown(handType);
    }

    public bool GetGrab() // 2
    {
        return grabAction.GetState(handType);
    }
    //public bool Movement() // 3
    //{
    //   // return moveAction.(handType);
    //}
    public bool ChangeView()
    {
        return ChangeViewAction.GetStateDown(handType);
    }
    public bool GetBuild()
    {
        return BuildAction.GetStateDown(handType);
    }

    public bool Preview()
    {
        return PreviewAction.GetStateDown(handType);
    }

}
