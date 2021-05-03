using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custscene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    Animator controller;
    public AudioSource text;
    void Start()
    {
        controller = GameObject.Find("Character_Male_King_01").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cube")
            controller.SetBool("Stand", true);

    }

    public void Talk()
    {
        controller.SetBool("Stand", false);
        text.Play();
        controller.SetBool("Talk", true);

    }
}
