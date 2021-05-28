using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Update_Capacity_Workers : MonoBehaviour
{
    private TextMeshPro textMesh;
    public GameObject parent = null;
    public GameObject manager;
 
    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
        parent = transform.parent.gameObject;
        manager = GameObject.Find("Workers_Manager").gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.name == "Minner")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().minners_capacity.ToString();

        }
        else if (parent.name == "Soldier")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().soldiers_capacity.ToString();

        }
        else if (parent.name == "Woodcutter")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().woodcutters_capacity.ToString();

        }
        else if (parent.name == "None")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_none_workers.ToString();

        }
        else if (parent.name == "Mage")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().mages_capacity.ToString();

        }
        if (parent.name == "Farmer")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().farmers_capacity.ToString();

        }

    }
}
