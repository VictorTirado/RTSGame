using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtPeople : MonoBehaviour
{

    public Animator m_Animator;

    public bool is_caught = false;
    // Start is called before the first frame update
    void Start()
    {

        m_Animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_caught == true)
        {

            m_Animator.SetBool("IsCaught", true);
           

        }
        else if (is_caught == false)
            m_Animator.SetBool("IsCaught", false);
    }
    public void ShowWorks()
    {
        this.transform.GetChild(13).gameObject.SetActive(true);
        foreach (Transform child in this.transform.GetChild(13))
        {

            child.gameObject.SetActive(true);

        }
    }
    
    }
