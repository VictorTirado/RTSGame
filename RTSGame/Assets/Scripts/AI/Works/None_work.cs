using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class None_work : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject door;


    public Vector3 dest;
    public Character_Manager cm;
    Collider m_collider;
    float timer = 0.0f;

    public bool LeaveResources = false;
    public bool HasResources = false;
    public bool SetPosition = false;
    public bool InPosition = false;
   

    //TODO: FUNCION PARA CUANDO SE MUERA
    //TODO: SETEAR UN PUNTO RANDOM AL QUE IR (AHORA ES UN CUBO)
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("TB_Bd_House_TwoStory_C").transform.GetChild(11).gameObject;
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();
        m_collider = GameObject.Find("TB_Bd_House_TwoStory_C").transform.GetChild(12).GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        agent = this.GetComponent<Character_Manager>().agent;
        if (this.GetComponent<CaughtPeople>().is_caught == false)
        {
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
            {
                if (cm.CheckLife() == true)
                {
                    GoToPos();
                    FindResources();
                    ReturnResources();
                    SetResources();
                }

            }
        }
    }
    private void GoToPos()
    {
        if (InPosition == false && HasResources == false && LeaveResources == false && SetPosition == false)
        {
            dest = RandomPointInBounds(m_collider.bounds);
            agent.SetDestination(dest);
            //agent.SetDestination(RandomPointInBounds(m_collider.bounds));
            //agent.SetDestination(pos.transform.position);
            cm.m_Animator.SetBool("isWalking", true);
            SetPosition = true;
        }
        if (LeaveResources == false)
        {
            agent.SetDestination(dest);
        }
        Debug.DrawLine(this.transform.position, dest);
        float distance = Vector3.Distance(this.transform.position, dest);
        if ((transform.position - dest).sqrMagnitude < 2f)
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
                    this.transform.GetChild(15).gameObject.SetActive(true);
                    this.transform.GetChild(12).gameObject.SetActive(true);
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
        }

    }
    private bool GetResources()
    {
        HasResources = true;
        return HasResources;
    }

    public  Vector3 RandomPointInBounds(Bounds bounds)
    {
        dest = new Vector3(Random.Range(bounds.min.x, bounds.max.x),0, Random.Range(bounds.min.z, bounds.max.z));
        return dest;
      
    }

    public void DestroyPerson()
    {
       
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.WoodCutter)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_woodcutters -= 1;
            else if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Minner)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_minners -= 1;
            else if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_soldiers -= 1;
            else if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_mages -= 1;
            else if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_none_workers -= 1;
            else if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Farmer)
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_farmers -= 1;


        // GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().UpdateWorkers();
        // GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_none_workers -= 1;
         Destroy(gameObject);

    }


}




