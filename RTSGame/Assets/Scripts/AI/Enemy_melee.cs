using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_melee : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    

    public int HP=100;
    public GameObject enemy_selected;
    public Animator m_Animator;

    public bool in_pos = false;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy_selected == null)
            FindClosestEnemy(); 
        else if(enemy_selected != null)
        {
            GoToEnemy();
            ShotEnemy();
        }


        if (HP <= 0)
        {
            m_Animator.SetBool("isDying", true);
            agent.Stop();
        }

        }

    private void GoToEnemy()
    {
        if (enemy_selected != null)
        {
            agent.SetDestination(enemy_selected.transform.position);
            agent.speed = 5.0f;
            m_Animator.SetBool("isWalking", true);
            float distanceToEnemy = (enemy_selected.transform.position - this.transform.position).sqrMagnitude;
            //Debug.Log(distanceToEnemy);
            if (distanceToEnemy <= 2.0f) in_pos = true;
            else if (distanceToEnemy >= 2.0f) in_pos = false;

        }
        if (in_pos == true) agent.isStopped = true;
        else if (in_pos == false) agent.isStopped = false;

    }

    private void ShotEnemy()
    {
        if (enemy_selected != null && in_pos == true)
        {
            m_Animator.SetBool("isShooting", true);

        }
        else
            m_Animator.SetBool("isShooting", false);
    }

    void FindClosestEnemy()
    {
        if (enemy_selected == null)
        {
            m_Animator.SetBool("isWalking", false);

            m_Animator.Play("Idle");


        }
        float distanceToClosestEnemy = 30000.0f;
        Character_Manager closestVillager = null;
        Character_Manager[] allvillagers = GameObject.FindObjectsOfType<Character_Manager>();


        foreach (Character_Manager currentEnemy in allvillagers)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestVillager = currentEnemy;
            }
        }
        if (closestVillager != null)
        {
            enemy_selected = closestVillager.gameObject;
            Debug.DrawLine(this.transform.position, closestVillager.transform.position);
            this.transform.LookAt(closestVillager.transform.position);
        }
    }

    public void Destroy()
    {
        Destroy(this);
    }
}
