using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP=100;

    public Animator m_Animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            m_Animator.SetBool("isDying", true);
           
    }
}
