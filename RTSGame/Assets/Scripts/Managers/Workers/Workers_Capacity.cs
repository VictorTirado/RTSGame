using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers_Capacity : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
       
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWorkersCap()
    {
        if (gameObject.layer == 11)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().mages_capacity += 2;

        else if (gameObject.layer == 12)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().soldiers_capacity += 2;

        else if (gameObject.layer == 13)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().minners_capacity += 2;

        else if (gameObject.layer == 14)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().woodcutters_capacity += 3;
        else if (gameObject.layer == 17)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().farmers_capacity += 3;
        else if (gameObject.layer == 18)
            GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().villagers_capacity += 4;
    }
}
