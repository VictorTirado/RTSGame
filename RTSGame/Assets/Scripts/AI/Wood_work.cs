using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wood_work : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject pos;
    public GameObject door;

    public GameObject bucket_01;
    public GameObject bucket_02;
    Character_Manager cm;

    float timer = 0.0f;

    public bool LeaveResources = false;
    public bool HasResources = false;

    public bool InPosition = false;
   

    //TODO: FUNCION PARA CUANDO SE MUERA
    //TODO: SETEAR UN PUNTO RANDOM AL QUE IR (AHORA ES UN CUBO)
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.WoodCutter)
        {
            GoToPos();
            FindResources();
            ReturnResources();
            SetResources();

        }
    }
    private void GoToPos()
    {
        if (InPosition == false && HasResources== false && LeaveResources == false)
        {
            agent.SetDestination(pos.transform.position);
            cm.m_Animator.SetBool("isWalking", true); 
        }

        float distance = Vector3.Distance(this.transform.position, pos.transform.position);
        //Debug.Log(distance);
        if (distance <= 3f)
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
            bucket_01.SetActive(true);
            bucket_02.SetActive(true);
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
                bucket_01.SetActive(false);
                bucket_02.SetActive(false);
            }
            if (this.transform.GetChild(8).gameObject.activeSelf == false || this.transform.GetChild(3).gameObject.activeSelf == false)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
            }
            if (timer >= 5.0f)
            {
                if (cm.gender == Character_Manager.Gender.Male)
                    this.transform.GetChild(8).gameObject.SetActive(true);

                if (cm.gender == Character_Manager.Gender.Female)
                    this.transform.GetChild(3).gameObject.SetActive(true);

          
                LeaveResources = false;
                timer = 0.0f;

                this.gameObject.transform.LookAt(pos.transform);
                cm.m_Animator.SetBool("IsFinding", false);
                cm.m_Animator.SetBool("IsWalking", true);
               
            }

            InPosition = false;
            HasResources = false;
        }

    }
    private bool GetResources()
    {
        HasResources = true;
        return HasResources;
    } 
}




