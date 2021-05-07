using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject door;
    public GameObject vegetable;
    public Vector3 dest;
    public Character_Manager cm;
    Collider m_collider;
    float timer = 0.0f;

    public bool LeaveResources = false;
    public bool HasResources = false;
    public bool SetPosition = false;
    public bool InPosition = false;
    public bool SetWorkPlace = false;


    //TODO: FUNCION PARA CUANDO SE MUERA
    //TODO: SETEAR UN PUNTO RANDOM AL QUE IR (AHORA ES UN CUBO)
    // Start is called before the first frame update
    void Start()
    {
        SetWorkPlace = false;
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();
        m_collider = GameObject.Find("TB_Bd_House_TwoStory_C").transform.GetChild(12).GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<CaughtPeople>().is_caught == false)
        {
            if (SetWorkPlace == false)
                PlaceToWork();
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Farmer)
            {
                GoToPos();
                FindResources();
                ReturnResources();
                SetResources();

            }
        }
    }
    private void GoToPos()
    {
        if (InPosition == false && HasResources == false && LeaveResources == false && SetPosition == false)
        {
           
            agent.SetDestination(vegetable.transform.position);
            cm.m_Animator.SetBool("isWalking", true);
            SetPosition = true;
        }
        if (LeaveResources == false)
        {
            agent.SetDestination(vegetable.transform.position);
        }
        Debug.DrawLine(this.transform.position, vegetable.transform.position);
        float distance = Vector3.Distance(this.transform.position, vegetable.transform.position);
        Debug.Log(distance);
        if (distance < 2.0f)
            InPosition = true;

       
        }

    private void FindResources()
    {

        if (InPosition == true)
        {
            cm.m_Animator.SetBool("isWalking", false);
            cm.m_Animator.SetBool("isFinding", true);
        }
    }

    private void ReturnResources()
    {
        if (HasResources == true)
        {
            cm.m_Animator.SetBool("isFinding", false);
           
           
            cm.m_Animator.SetBool("isWalking", true);
            agent.SetDestination(door.transform.position);
            
            if ((transform.position - door.transform.position).sqrMagnitude < 2f)
                LeaveResources = true;
        }
    }
    private void SetResources()
    {
       
        if (LeaveResources == true)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
              
              
            }
            if (this.transform.GetChild(8).gameObject.activeSelf == false || this.transform.GetChild(3).gameObject.activeSelf == false)
            {
                timer += Time.deltaTime;
                
            }
            if (timer >= 5.0f)
            {
                if (cm.gender == Character_Manager.Gender.Male)
                {
                    this.transform.GetChild(8).gameObject.SetActive(true);
                    this.transform.GetChild(12).gameObject.SetActive(true);
                    this.transform.GetChild(15).gameObject.SetActive(true);
                }

                if (cm.gender == Character_Manager.Gender.Female)
                {
                    this.transform.GetChild(3).gameObject.SetActive(true);
                    this.transform.GetChild(12).gameObject.SetActive(true);
                    this.transform.GetChild(15).gameObject.SetActive(true);
                }


                    LeaveResources = false;
                timer = 0.0f;

                this.gameObject.transform.LookAt(dest);
                cm.m_Animator.SetBool("IsFinding", false);
                cm.m_Animator.SetBool("IsWalking", true);
               
            }

            InPosition = false;
            HasResources = false;
            SetPosition = false;
            SetWorkPlace = false;
        }

    }
    private bool GetResources()
    {
        HasResources = true;
        return HasResources;
    }



    public void PlaceToWork()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200.0f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Door_Farm")
                door = hitCollider.gameObject;
            else if (hitCollider.tag == "Vetegable")
                vegetable = hitCollider.gameObject;
        }
       
        SetWorkPlace = true;
    }
}




