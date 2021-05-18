using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRController : MonoBehaviour
{
    public float m_sensitivity = 0.1f;
    public float m_MaxSpeed = 5.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_speed = 0.0f;

    private CharacterController m_characterController = null;
    private Transform m_cameraRig = null;
    private Transform m_Head = null;
    public bool PlayerIsInFloor = false;
    public GameObject commander;

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_cameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
        commander = GameObject.FindGameObjectWithTag("Commander");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("VRController").GetComponent<asd>().peasant == true)
        {

            //GameObject.Find("Canvas").SetActive(false);
            //if (PlayerIsInFloor == false)
            //{
            //    PlayerInFloor();
            //}
            HandleHead();
            CalculateMovement();
            HandleHeight();
        }
        //else if(GameObject.Find("VRController").GetComponent<asd>().peasant == false)
        //    PlayerInAir();


    }
    private void HandleHead()
    {
        Vector3 oldPosition = m_cameraRig.position;
        Quaternion oldRotation = m_cameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        m_cameraRig.position = oldPosition;
        m_cameraRig.rotation = oldRotation;
    }
    private void CalculateMovement()
    {
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;


        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
            m_speed = 0;

        if (m_MovePress.state)
        {
            m_speed += m_MoveValue.axis.y * m_sensitivity;
            m_speed = Mathf.Clamp(m_speed, -m_MaxSpeed, m_MaxSpeed);

            movement += orientation * (m_speed * Vector3.forward) * Time.deltaTime;

            m_characterController.Move(movement);

        }

       
    }

    private void HandleHeight()
    {
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_characterController.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_characterController.height / 2;
        newCenter.y += m_characterController.skinWidth;

        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        m_characterController.center = newCenter;
    }

    public void PlayerInFloor()
    {
        if(this.transform.position.y>=5)
        {
            PlayerIsInFloor = true;
            //fVector3 pos = new Vector3(this.transform.position.x, 0.0f,this.transform.position.z);
            this.transform.position = commander.transform.position;
           
            commander.gameObject.SetActive(false);
            GameObject.Find("Controller (right)").GetComponent<LaserPointer>().PlayerIsInAir = false;
        }
      
    }
    public void PlayerInAir()
    {
       
      
           // PlayerIsInFloor = true;
            Vector3 pos = new Vector3(this.transform.position.x, 20.0f, this.transform.position.z);
            commander.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            this.transform.position = pos;
        commander.gameObject.SetActive(true);
            GameObject.Find("Controller (right)").GetComponent<LaserPointer>().PlayerIsInAir = true;
        PlayerIsInFloor = false;
      

    }
}