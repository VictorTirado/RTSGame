using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowResources : MonoBehaviour
{
    private TextMeshPro woodmesh;
    private TextMeshPro woodmeshbenefits;
    private TextMeshPro foodmeshbenefits;
    private TextMeshPro goldmeshbenefits;
    private TextMeshPro foodmesh;
    private TextMeshPro goldmesh;
    private TextMeshPro n_villager;
    private TextMeshPro number_villager;
    private TextMeshPro max_villagers;
    private TextMeshPro happiness;
    Resources_Manager rm;
    // Start is called before the first frame update
    void Start()
    {
        woodmesh = gameObject.GetComponent<TextMeshPro>();
        foodmesh = gameObject.GetComponent<TextMeshPro>();
        goldmesh = gameObject.GetComponent<TextMeshPro>();
        woodmeshbenefits = gameObject.GetComponent<TextMeshPro>();
        foodmeshbenefits = gameObject.GetComponent<TextMeshPro>();
        goldmeshbenefits = gameObject.GetComponent<TextMeshPro>();
        n_villager = gameObject.GetComponent<TextMeshPro>();
        happiness = gameObject.GetComponent<TextMeshPro>();
        number_villager = gameObject.GetComponent<TextMeshPro>();
        max_villagers = gameObject.GetComponent<TextMeshPro>();
        rm = GameObject.Find("Resources_manager").GetComponent<Resources_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float timer_villager = 45 - GameObject.Find("TB_Bd_House_TwoStory_C").GetComponent<SpawnVillagers>().timer;
        if (this.name == "Wood_number")
            woodmesh.text = rm.wood.ToString("0");
        else if (this.name == "Food_number")
            foodmesh.text = rm.food.ToString("0");
        else if (this.name == "Gold_number")
            goldmesh.text = rm.gold.ToString("0");


        if (this.name == "Benefits_wood")
            woodmeshbenefits.text = rm.wood_benefits.ToString("0");
        else if (this.name == "Benefits_food")
            foodmeshbenefits.text = rm.food_benefits.ToString("0");
        else if (this.name == "Benefits_gold")
            goldmeshbenefits.text = rm.gold_benefits.ToString("0");

        if (this.name == "Next_villager")
            n_villager.text = timer_villager.ToString("0");

        if (this.name == "Happines_text")
            happiness.text = rm.hapiness.ToString("0");
        if (this.name == "Number_villagers")
            number_villager.text = rm.villagers.ToString("0");
        if (this.name == "Max_villagers")
            max_villagers.text = rm.max_villagers.ToString("0");

    }
}
