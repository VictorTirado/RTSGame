using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    

    public int HP=100;
    public GameObject enemy_selected;
    public Animator m_Animator;

    public GameObject fireball;

    public bool in_pos = false;

    bool alive = true;

    public float distanceToClosestEnemy = 30000.0f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLife() == true)
        {
            if (enemy_selected == null)
                FindClosestEnemy();

            else if (enemy_selected != null)
            {
                GoToEnemy();
                ShotEnemy();
            }
        }


        //if (HP <= 0)
        //{
        //    m_Animator.SetBool("isDying", true);
        //    agent.Stop();
        //}
     
        }

    private void GoToEnemy()
    {
        if (enemy_selected != null)
        {
            agent.SetDestination(enemy_selected.transform.position);
            m_Animator.SetBool("isWalking", true);
            float distanceToEnemy = (enemy_selected.transform.position - this.transform.position).sqrMagnitude;
            //Debug.Log(distanceToEnemy);
            if (distanceToEnemy <= 400.0f) in_pos = true;
            else if (distanceToEnemy >= 400.0f) in_pos = false;

        }
        if (in_pos == true) agent.isStopped = true;
        else if (in_pos == false) agent.isStopped = false;

    }

    private void ShotEnemy()
    {
        if (enemy_selected != null && in_pos == true)
        {
            m_Animator.SetBool("isShooting", true);
            m_Animator.speed = 0.96f;
        }
        else
        {
            m_Animator.SetBool("isShooting", false);
            m_Animator.speed = 1.0f;
        }
    }

    void FindClosestEnemy()
    {
        if (enemy_selected == null)
        {
            m_Animator.SetBool("isWalking", false);

            m_Animator.Play("Idle");


        }
      
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

    public void Cast()
    {
        // new Vector3 = this.transform.Find("Hand_L").transform.position;
        var fake_fireball = Instantiate(fireball, this.transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L/Shoulder_L/Elbow_L/Hand_L").gameObject.transform.position, transform.rotation);
        fake_fireball.GetComponent<Projectil_2>().enemy = enemy_selected;
    }

    public void DestroyPerson()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToClosestEnemy);
    }

    public bool CheckLife()
    {
        if (HP <= 0)
        {
            alive = false;
            m_Animator.SetBool("isDying", true);
            agent.Stop();

            return alive;
        }

        return alive;
    }
}
