using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Warrior : MonoBehaviour
{
    private NavMeshAgent agent;
    Character_Manager cm;

    public bool InPosition = false;
  
    public int closestCharacter = 0;
    public GameObject enemy;

    public GameObject sword = null;


    public bool in_pos = false; 
    public int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
       
        //fGameObject.Find("SM_Prop_SwordOrnate_01").gameObject.GetComponent<MeshRenderer>().enabled = true;
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        sword.transform.gameObject.SetActive(true);
        if (this.GetComponent<CaughtPeople>().is_caught == false || cm.has_to_move  == false)
        {
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
            {
                if (cm.CheckLife() == true)
                {
                    FindClosestEnemy();
                    if (cm.has_to_move == true)
                        GoToPos(GameObject.Find("Controller (right)").GetComponent<Move_Workers>().hitPoint);
                    if (cm.has_to_move == false)
                        GoToEnemy();

                    //    GoToEnemy();
                    //GoToPos();
                    if (enemy != null && cm.has_to_move == false)
                        HitEnemy();
                   
                }

            }
        }
    }
    private void GoToPos(Vector3 dest)
    {
        Debug.Log("HIIIIIIIIIIII");
        //agent.Resume();
        cm.m_Animator.SetBool("isHitting", false);
        cm.m_Animator.SetBool("isWalking", true);
        agent.Resume();
        agent.SetDestination(dest);

        float distance = Vector3.Distance(this.transform.position, dest);
       // Debug.Log(distance);
        if ((transform.position - dest).sqrMagnitude < 2.0f)
        {
            cm.m_Animator.SetBool("isWalking", false);
            cm.has_to_move = false;
        }



    }

    private void GoToEnemy()
    {
        if (enemy != null)
        {
            agent.SetDestination(enemy.transform.position);
            cm.m_Animator.SetBool("isWalking", true);
            float distanceToEnemy = (enemy.transform.position - this.transform.position).sqrMagnitude;
            //Debug.Log(distanceToEnemy);
            if (distanceToEnemy <= 3.0f) in_pos = true;
            else if (distanceToEnemy >= 5.0f) in_pos = false;

        }
        if (in_pos == true) agent.isStopped = true;
        else if (in_pos == false) agent.isStopped = false;

    }

    //private void CheckLife()
    //{
    //    if(HP<=0)
    //    {
    //        cm.m_Animator.SetBool("IsDying", true);
    //    }
    //}
   

    void FindClosestEnemy()
    {
        if (enemy == null && cm.has_to_move == false)
        {
            //cm.m_Animator.SetBool("isWalking", false);

            cm.m_Animator.Play("Idle");


        }
        float distanceToClosestEnemy = 600.0f;
        GameObject closestEnemy = null;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");


        foreach(GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
           
            if(distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        if (closestEnemy != null)
        {
            enemy = closestEnemy.gameObject;
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
            this.transform.LookAt(closestEnemy.transform.position);  
        }
    }

    private void HitEnemy()
    {

        if (enemy != null && in_pos == true)
        {
            cm.m_Animator.speed = 0.9f;
            cm.m_Animator.SetBool("isHitting", true);

        }
        else
        {
            cm.m_Animator.speed = 1.0f;
            cm.m_Animator.SetBool("isHitting", false);
        }
    }

    //public void DestroyPerson()
    //{

       
      
    //    Destroy(gameObject);
    //}
    

    public void Damage()
    {
        if(enemy.GetComponent<enemy>()!=null)
            enemy.GetComponent<enemy>().HP -= 6;
        if (enemy.GetComponent<Enemy_melee>() != null)
            enemy.GetComponent<Enemy_melee>().HP -= 6;

    }

}




