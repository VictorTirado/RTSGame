using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers_Samwill : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().woodcutters_capacity += 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
