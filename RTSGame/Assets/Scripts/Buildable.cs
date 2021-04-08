using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public bool isBuildable = true;

    private int _collisionHit = 0;

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
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building") _collisionHit--;
    }
}
