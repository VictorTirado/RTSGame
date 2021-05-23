using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers_Manager : MonoBehaviour
{
    public GameObject workers;

    public int woodcutters_capacity = 0;
    public int current_woodcutters = 0;

    public int soldiers_capacity = 0;
    public int current_soldiers= 0;

    public int mages_capacity = 0;
    public int current_mages = 0;

    public int minners_capacity = 0;
    public int current_minners = 0;

    public int farmers_capacity = 0;
    public int current_farmers = 0;

    public int current_none_workers = 0;
    public int current_buildings = 0;
    bool first_update = false;
    public GameObject Building_Manager;

    public int villagers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        villagers = current_mages + current_minners + current_none_workers + current_soldiers + current_woodcutters + current_farmers + 1;
        
      if (first_update== false)
        {
            CurrentBuildings();
            UpdateWorkers();
            first_update = true;
        }

    }

    public void UpdateWorkers()
    {
        foreach (Transform child in GameObject.Find("Villagers").transform)
        {
            if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.WoodCutter)
                current_woodcutters += 1;
            else if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Minner)
                current_minners += 1;
            else if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
                current_soldiers += 1;
            else if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
                current_mages += 1;
            else if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.None)
                current_none_workers += 1;
            else if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Farmer)
                current_farmers += 1;


        }
    }

    public void ResetWorkers()
    {
        current_mages = 0;
        current_minners = 0;
        current_none_workers = 0;
        current_soldiers = 0;
        current_woodcutters = 0;
        current_farmers = 0;
    }


    public void CurrentBuildings()
    {
     
        foreach(Transform child in Building_Manager.transform)
        {
            if (child.tag == "Building")
                current_buildings += 1;
        }
    }
}
