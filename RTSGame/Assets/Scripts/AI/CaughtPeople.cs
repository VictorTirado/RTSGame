using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtPeople : MonoBehaviour
{

    public GameObject Left_Hand = null;
    public GameObject Right_Hand = null;

    public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        Left_Hand = GameObject.Find("Controller (left)").GetComponent<ControllerGrabObject>().objectInHand;
        Right_Hand = GameObject.Find("Controller (right)").GetComponent<ControllerGrabObject>().objectInHand;

        m_Animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Left_Hand = GameObject.Find("Controller (left)").GetComponent<ControllerGrabObject>().objectInHand;
        Right_Hand = GameObject.Find("Controller (right)").GetComponent<ControllerGrabObject>().objectInHand;

        if (Left_Hand.gameObject == this.gameObject || Right_Hand.gameObject == this.gameObject)
        {
            this.GetComponent<None_work>().enabled = false;
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("isWalking"))
                m_Animator.SetBool("isWalking", false);
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("isFinding"))
                m_Animator.SetBool("isFinding", false);

            m_Animator.SetBool("IsCaught", true);
        }
        else
        {
            this.GetComponent<None_work>().enabled = true;
            m_Animator.SetBool("IsCaught", false);
        }

        }
}
