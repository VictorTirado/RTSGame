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
        if (this.GetComponent<CaughtPeople>().is_caught == false)
        {
            if (this.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
            {
                if (cm.CheckLife() == true)
                {
                    FindClosestEnemy();
                    GoToPos();
                    ShotEnemy();
                }

            }
        }
    }
    private void GoToPos()
    {
       

      

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
        if (cm.m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            Debug.Log("ENTRANDO");
            float distanceToClosestEnemy = 1000.0f;
            enemy closestEnemy = null;
            enemy[] allEnemies = GameObject.FindObjectsOfType<enemy>();


            foreach (enemy currentEnemy in allEnemies)
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
        if (enemy != null)
        {
            cm.m_Animator.SetBool("isShooting", true);

        }
        else
            cm.m_Animator.SetBool("isShooting", false);
    }

    public void Cast()
    {
       // new Vector3 = this.transform.Find("Hand_L").transform.position;
        Instantiate(fireball, this.transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L/Shoulder_L/Elbow_L/Hand_L").gameObject.transform.position, transform.rotation);
    }


}




