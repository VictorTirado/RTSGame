using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Lose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Sazed").GetComponent<Character_Manager>().HP <= 0)
            Time.timeScale = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIIIIIIIIIIIII");
        if (other.tag == "Commander" || other.tag == "People")
            Time.timeScale = 0;
        
       
    }
}
