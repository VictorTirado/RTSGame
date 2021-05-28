using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Update_Current_Workers : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshPro textMesh;
    public GameObject parent = null;
    public GameObject manager;
   
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshPro>();
        parent = transform.parent.gameObject;
        manager = GameObject.Find("Workers_Manager").gameObject;
     
    
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.name =="Minner")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_minners.ToString();

        }
        else if (parent.name == "Soldier")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_soldiers.ToString();

        }
        else if (parent.name == "Woodcutter")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_woodcutters.ToString();

        }
        else if (parent.name == "None")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_none_workers.ToString();

        }
        else if (parent.name == "Mage")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_mages.ToString();

        }
        if (parent.name == "Farmer")
        {
            textMesh.text = manager.GetComponent<Workers_Manager>().current_farmers.ToString();

        }
    }
}
