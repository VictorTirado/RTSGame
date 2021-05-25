using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWood : MonoBehaviour
{
    // Start is called before the first frame update
    int hits = 5;
    public GameObject trunk;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Axe")
        {
            hits -= 1;

            if (hits == 0)
            {
                hits = 5;
                Instantiate(trunk,this.transform);
            }

        }

    }
}
