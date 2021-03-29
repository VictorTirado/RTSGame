using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character_Manager : MonoBehaviour
{
    public enum Character { None, Soldier, WoodCutter, Minner };
    public enum Gender { Male, Female, None };
    public Character work_type = Character.None;
    public Gender gender = Gender.None;

    public NavMeshAgent agent;
    public GameObject pos;

    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        SetGender();
        work_type = Character.None;
        m_Animator = transform.GetComponent<Animator>();
        SetWork();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void SetWork()
    {
        //MALE
        if(work_type == Character.None && gender == Gender.Male)
        {
            this.transform.GetChild(8).gameObject.SetActive(true);
           
        }

        //FEMALE
        if (work_type == Character.None && gender == Gender.Female)
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
           // m_Animator.SetBool("isWalking", false);
        }
    }


    private void SetGender()
    {
       int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            Debug.Log(rand);
            this.gender = Gender.Male;
        }
        else if(rand == 1)
        {
            Debug.Log(rand);
            this.gender = Gender.Female;
        }

        m_Animator.SetBool("isWalking", false);

    }
}
