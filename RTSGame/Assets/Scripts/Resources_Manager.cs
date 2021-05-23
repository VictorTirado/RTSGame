using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    public int hapiness = 0;

    float timer_wood = 0.0f;
   
    float timer_gold = 0.0f;
    //FOOD
 
    public float food = 0;
    public float timer_spend_food = 0.0f;
    public float timer_add_food = 0.0f;
    public float spend_food_in_minute = 0.0f;
    public float food_add_in_minute = 0.0f;

    //WOOD
    public float wood = 115;
    public float timer_spend_wood = 0.0f;
    public float timer_add_wood = 0.0f;
    public float spend_wood_in_minute = 0.0f;
    public float wood_add_in_minute = 0.0f;

    //GOLD
    public float gold = 0;
    public float timer_spend_gold = 0.0f;
    public float timer_add_gold = 0.0f;

    float spend_wood = 0.0f;
    float add_wood = 0.0f;

    Workers_Manager wm;
    void Start()
    {
        wm = GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //FOOD
        timer_add_food += Time.deltaTime;
        timer_spend_food += Time.deltaTime;


        if(timer_add_food>=1.0f)
        {
            food += (wm.current_none_workers * 0.265f + wm.current_farmers * 0.53f - wm.villagers * 0.1749f);
            timer_add_food = 0.0f;
        }

        //spend_food_in_minute = wm.villagers *1*2;
        //food_add_in_minute = wm.villagers * 3 * 1.5f;

       
        //if (timer_spend_food >= (60/ spend_food_in_minute))
        //{
        //    food -= 1;
        //    timer_spend_food = 0.0f;
        //}

        //if (timer_add_food>=(60/food_add_in_minute))
        //{
        //    food += 1 ;
        //    timer_add_food = 0.0f;
        //}

        //WOOD

        timer_add_wood += Time.deltaTime;
        timer_spend_wood += Time.deltaTime;

        if (timer_add_wood >= 1.0f)
        {
            wood += (wm.current_woodcutters * 0.39f - wm.current_buildings * 0.1749f);
            timer_add_wood = 0.0f;
        }
        //spend_wood_in_minute = 3 * wm.current_buildings;
        //wood_add_in_minute = wm.current_woodcutters * 2 * 4;


        //if (timer_spend_wood >= (60 / spend_wood_in_minute))
        //{
        //    wood -= 1;
        //    timer_spend_wood = 0.0f;
        //}

        //if (timer_add_wood >= (60 / wood_add_in_minute))
        //{
        //    wood += 1;
        //    timer_add_wood = 0.0f;
        //}


        timer_add_gold += Time.deltaTime;
        timer_spend_gold += Time.deltaTime;

        if (timer_add_gold >= 1.0f)
        {
            gold += (wm.current_minners * 0.38f);
            timer_add_gold = 0.0f;
        }
        //HAPINESS
        if (food_add_in_minute - spend_food_in_minute >= 5)
            hapiness = 2;
        else if (food_add_in_minute - spend_food_in_minute > 5 && food_add_in_minute - spend_food_in_minute <= 0)
            hapiness = 1;
        else if (food_add_in_minute - spend_food_in_minute < 0)
            hapiness = 0;

    }
}
