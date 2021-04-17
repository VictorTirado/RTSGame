using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWork : MonoBehaviour
{
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
       
        this.transform.root.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        
        this.transform.root.GetComponent<Character_Manager>().update_work = true;
    }
}
