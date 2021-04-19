using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWork : MonoBehaviour
{

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
       
        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);

        parent.GetComponent<Character_Manager>().update_work = true;
        GameObject.Find("Controller (right)").GetComponent<GetPeople2>().set_people = true;
    }
}
