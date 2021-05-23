using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowResources : MonoBehaviour
{
    private TextMeshPro woodmesh;
    private TextMeshPro foodmesh;
    private TextMeshPro goldmesh;
    Resources_Manager rm;
    // Start is called before the first frame update
    void Start()
    {
        woodmesh = gameObject.GetComponent<TextMeshPro>();
        foodmesh = gameObject.GetComponent<TextMeshPro>();
        goldmesh = gameObject.GetComponent<TextMeshPro>();
        rm = GameObject.Find("Resources_manager").GetComponent<Resources_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "Wood_number")
            woodmesh.text = rm.wood.ToString("0");
        else if (this.name == "Food_number")
            foodmesh.text = rm.food.ToString("0");
        else if (this.name == "Gold_number")
            goldmesh.text = rm.gold.ToString("0");

    }
}
