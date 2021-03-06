using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public bool isBuildable = true;

    private int _collisionHit = 0;


    private void Start()
    {
        this.GetComponent<BoxCollider>().isTrigger = true;
    }
    void Update()
    {
        Debug.Log(_collisionHit);
  
        if (_collisionHit > 0)
        {
            isBuildable = false;
            this.gameObject.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Incorrect");
         
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Correct");
            isBuildable = true;
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building") _collisionHit++;
        if (other.gameObject.tag == "Preview") _collisionHit++;
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building") _collisionHit--;
    }
}
