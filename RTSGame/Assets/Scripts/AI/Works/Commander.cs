using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    public Character_Manager cm;
    public Animator m_Animator;
    int save_life;

    public float timer_1;
    // Start is called before the first frame update
    void Start()
    {
        cm = this.transform.GetComponent<Character_Manager>();
        m_Animator = this.GetComponent<Animator>();
        save_life = cm.HP;
    }

    // Update is called once per frame
    void Update()
    {
        timer_1 += Time.deltaTime;

        if (timer_1 >= 5.0f)
        {
            RecoverLife();
            timer_1 = 0.0f;
        }
        if (cm.HP <= 0)
        {
            m_Animator.SetBool("isDying", true);
           
        }
    }

    public void RecoverLife()
    {
        
        cm.HP += 2;
    }
}
