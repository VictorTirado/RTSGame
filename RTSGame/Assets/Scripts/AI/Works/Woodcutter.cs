using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Woodcutter : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject pos;
    public GameObject tree;
    public GameObject axe;
    public Vector3 dest;
    public Character_Manager cm;
   
    float timer = 0.0f;
    public int resources = 0;
    public bool LeaveResources = false;
    public bool HasResources = false;
    public bool SetPosition = false;
    public bool InPosition = false;
    public bool SetWorkPlace = false;
    public CapsuleCollider myCollider;
    public Vector2 randomposition;
    // Start is called before the first frame update
    void Start()
    {
      
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();
      

    }

    // Update is called once per frame
    void Update()
    {
        axe.gameObject.SetActive(true);

        if (this.GetComponent<CaughtPeople>().is_caught == false)
        {
            if (SetWorkPlace == false)
                PlaceToWork();
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.WoodCutter)
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
            randomposition = Random.insideUnitCircle * myCollider.radius;
            dest = tree.transform.position;
            dest.x += randomposition.x;
            dest.z += randomposition.y;
            agent.SetDestination(dest);

            cm.m_Animator.SetBool("isWalking", true);
            SetPosition = true;
        }
        if (LeaveResources == false)
        {
            agent.SetDestination(dest);
        }
        Debug.DrawLine(this.transform.position, dest);
        
        float distance = Vector3.Distance(this.transform.position, dest);
        //Debug.Log(distance);
        if ((transform.position - dest).sqrMagnitude <= 2.0f)
            InPosition = true;


    }

    private void FindResources()
    {

        if (InPosition == true)
        {
            this.transform.LookAt(tree.transform);
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
            agent.SetDestination(pos.transform.position);
        
            if ((transform.position - pos.transform.position).sqrMagnitude < 2.5f)
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
            resources = 0;
            InPosition = false;
            HasResources = false;
            SetPosition = false;
        }

    }
    private void GetResources()
    {
        //cm.m_Animator.Play("Base.Minning");
        resources += 1;
        if (resources >= 3)
            HasResources = true;
      
        

    }

    public void PlaceToWork()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 200.0f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Door_Samwill")
                pos = hitCollider.gameObject;
            else if (hitCollider.tag == "Tree")
                tree = hitCollider.gameObject;
        }
        myCollider = tree.transform.GetComponent<CapsuleCollider>();
        Debug.Log(myCollider.radius);
        SetWorkPlace = true;
    }



}
