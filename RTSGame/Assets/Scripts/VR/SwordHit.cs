using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
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
        if (other.tag == "Enemy")
        {
            if(other.GetComponent<enemy>()!=null)
                other.GetComponent<enemy>().HP -= 15;
            else if(other.GetComponent<Enemy_melee>()!=null)
                other.GetComponent<Enemy_melee>().HP -= 15;
        }
    }
}
