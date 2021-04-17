using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers_Manager : MonoBehaviour
{
    public GameObject workers;

    public int woodcutters_capacity = 0;
    public int current_woodcutters = 0;
    public int soldiers_capacity = 0;
    public int mage_capacity = 0;
    public int minners_capacity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        foreach (Transform child in GameObject.Find("Villagers").transform)
        {
            if (child.GetComponent<Character_Manager>().work_type == Character_Manager.Character.WoodCutter)
                current_woodcutters += 1;
           
        }

    }
}
