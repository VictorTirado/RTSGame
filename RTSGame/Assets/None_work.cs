using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class None_work : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<Character_Manager>().agent;

    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
        {
            agent.SetDestination(pos.transform.position);
            Debug.Log("Que pasa fiera");

        }
    }
}
