using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mage : MonoBehaviour
{
    private NavMeshAgent agent;
    Character_Manager cm;

    public bool InPosition = false;
    public float[] Distance;
    public int closestCharacter = 0;
    public GameObject enemy;

    public GameObject fireball;


    public int HP = 100;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<Character_Manager>().agent;
        cm = this.transform.GetComponent<Character_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<CaughtPeople>().is_caught == false ||cm.has_to_move == false)
        {
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
            {
                if (cm.CheckLife() == true)
                {
                    FindClosestEnemy();
                    if (cm.has_to_move == true)
                        GoToPos(GameObject.Find("Controller (right)").GetComponent<Move_Workers>().hitPoint);
                    //GoToPos();
                 
                        ShotEnemy();
                 
                }

            }
        }
    }
    public void GoToPos(Vector3 dest)
    {
        agent.Resume();
        cm.m_Animator.SetBool("isShooting", false);
        cm.m_Animator.SetBool("isWalking", true);
        agent.SetDestination(dest);

        float distance = Vector3.Distance(this.transform.position, dest);
        Debug.Log(distance);
        if ((transform.position - dest).sqrMagnitude < 2.0f)
        {
            cm.m_Animator.SetBool("isWalking", false);
            cm.has_to_move = false;
        }


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
        if(enemy == null)
            cm.m_Animator.SetBool("isShooting", false);
        if (cm.m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            Debug.Log("ENTRANDO");
            float distanceToClosestEnemy = 1000.0f;
            GameObject closestEnemy = null;
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");


            foreach (GameObject currentEnemy in allEnemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                Debug.Log(distanceToEnemy);
                if (distanceToEnemy < distanceToClosestEnemy)
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
    }

    private void ShotEnemy()
    {
        this.transform.LookAt(enemy.transform.position);
        if (enemy != null)
        {
            cm.m_Animator.SetBool("isShooting", true);
            cm.m_Animator.speed = 1.0f;

        }
        else
            cm.m_Animator.SetBool("isShooting", false);

    }

    public void Cast()
    {
      if(enemy != null)
            Instantiate(fireball, this.transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L/Shoulder_L/Elbow_L/Hand_L").gameObject.transform.position, transform.rotation);
    }


    //public void DestroyPerson()
    //{
      
    //    Destroy(gameObject);
    //}
}




