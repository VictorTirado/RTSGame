﻿using System.Collections;
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
        sword.transform.gameObject.SetActive(true);
        //fGameObject.Find("SM_Prop_SwordOrnate_01").gameObject.GetComponent<MeshRenderer>().enabled = true;
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
        {
            CheckLife();
            FindClosestEnemy();
            GoToEnemy();
            GoToPos();
            HitEnemy();

        }
    }
    private void GoToPos()
    {

       


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

    private void CheckLife()
    {
        if(HP<=0)
        {
            cm.m_Animator.SetBool("IsDying", true);
        }
    }
    //private void CheckEnemies()
    //{
      
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 500.00f);
       
    //    for (var i = 0; i < hitColliders.Length; i++)
    //    {

    //        if (hitColliders[i].tag == "Enemy")
    //        {
    //            //enemies += 1;
    //            Debug.Log("enemy detected" + hitColliders[i].name);
    //            //this.transform.LookAt(hitColliders[i].transform.position);

    //            float distance = (hitColliders[i].transform.position - this.transform.position).magnitude;
    //           // Distance[i] = distance;
    //            if (distance < near_enemy)
    //            {
    //                near_enemy = distance;
    //                enemy = hitColliders[i].gameObject;
                   

    //            }
               
    //        }
            
    //    }
      
    //}

    void FindClosestEnemy()
    {
        if (enemy == null)
        {
            cm.m_Animator.SetBool("isWalking", false);

            cm.m_Animator.Play("Idle");


        }
        float distanceToClosestEnemy = 600.0f;
        enemy closestEnemy = null;
        enemy[] allEnemies = GameObject.FindObjectsOfType<enemy>();


        foreach(enemy currentEnemy in allEnemies)
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
            cm.m_Animator.SetBool("isHitting", true);

        }
        else
            cm.m_Animator.SetBool("isHitting", false);
    }

   
}



