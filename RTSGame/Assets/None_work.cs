using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class None_work : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject pos;
    Character_Manager cm;

    private bool InPosition = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
        {
            GoToPos();
            FindResources();

        }
    }
    private void GoToPos()
    {
        if (InPosition == false)
        {
            agent.SetDestination(pos.transform.position);
            cm.m_Animator.SetBool("isWalking", true);

            //Debug.Log("PUTO");

        }
        float distance = Vector3.Distance(this.transform.position, pos.transform.position);
        Debug.Log((transform.position - pos.transform.position).sqrMagnitude);
        if ((transform.position - pos.transform.position).sqrMagnitude < 2f)
        {
            InPosition = true;
            Debug.Log("HOLAAAA");
        }
        }

    private void FindResources()
    {

        if (InPosition == true)
        {
            Debug.Log("ADIOOS");
            cm.m_Animator.SetBool("isFinding", true);
        }
    }
}




