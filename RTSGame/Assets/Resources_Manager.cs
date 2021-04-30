using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int gold = 0;
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
    public int wood = 0;
    public float timer_spend_wood = 0.0f;
    public float timer_add_wood = 0.0f;
    public float spend_wood_in_minute = 0.0f;
    public float wood_add_in_minute = 0.0f;

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

        spend_food_in_minute = wm.villagers *1*2;
        food_add_in_minute = wm.villagers * 3 * 1.5f;

       
        if (timer_spend_food >= (60/ spend_food_in_minute))
        {
            food -= 1;
            timer_spend_food = 0.0f;
        }

        if (timer_add_food>=(60/food_add_in_minute))
        {
            food += 1 ;
            timer_add_food = 0.0f;
        }

        //WOOD

        timer_add_wood += Time.deltaTime;
        timer_spend_wood += Time.deltaTime;

        spend_wood_in_minute = 3 * wm.current_buildings;
        wood_add_in_minute = wm.current_woodcutters * 2 * 4;


        if (timer_spend_wood >= (60 / spend_wood_in_minute))
        {
            wood -= 1;
            timer_spend_wood = 0.0f;
        }

        if (timer_add_wood >= (60 / wood_add_in_minute))
        {
            wood += 1;
            timer_add_wood = 0.0f;
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
