using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWood : MonoBehaviour
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
        
          
            GameObject.Find("Resources_manager").GetComponent<Resources_Manager>().wood += 5;
            Destroy(this.gameObject);
    
    }
}
