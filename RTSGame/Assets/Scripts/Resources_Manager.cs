using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    public int hapiness = 0;

    //FOOD
 
    public float food = 0;
    public float food_benefits = 20;
    public float timer_add_food = 0.0f;


    //WOOD
    public float wood = 115;
    public float wood_benefits = 20;
    public float timer_add_wood = 0.0f;


    //GOLD
    public float gold = 0.0f;
    public float gold_benefits = 0.0f;
    private float timer_add_gold = 0.0f;


    public int villagers;
    public int max_villagers;
    Workers_Manager wm;
    void Start()
    {
        wm = GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        villagers = GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().villagers;
        max_villagers = GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().villagers_capacity;

        //FOOD
        timer_add_food += Time.deltaTime;
       
        food_benefits = (wm.current_none_workers * 0.3194f + wm.current_farmers * 0.53f - wm.villagers * 0.1749f)*60;

        if (timer_add_food>=1.0f)
        {
            food += (wm.current_none_workers * 0.3194f + wm.current_farmers * 0.53f - wm.villagers * 0.1749f);
            timer_add_food = 0.0f;
        }

    

        //WOOD

        timer_add_wood += Time.deltaTime;

        wood_benefits = (wm.current_woodcutters * 0.78f - wm.current_buildings * 0.1749f) * 60;

        if (timer_add_wood >= 1.0f)
        {
            wood += (wm.current_woodcutters * 0.78f - wm.current_buildings * 0.1749f);
            timer_add_wood = 0.0f;
        }
      
        //GOLD

        timer_add_gold += Time.deltaTime;
      
        gold_benefits = (wm.current_minners * 0.38f) * 60;

        if (timer_add_gold >= 1.0f)
        {
            gold += (wm.current_minners * 0.38f);
            timer_add_gold = 0.0f;
        }

        //HAPINESS

        if (food >= 300)
            hapiness = 1;
        else if (food < 0)
            hapiness = 0;

    }
}
