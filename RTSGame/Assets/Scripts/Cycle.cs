using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{

    public enum seasons { Summer, Autum, Winter, Spring};
    public Material skybox_1;
    public Material skybox_2;
    public seasons actual_season = seasons.Spring;
   
    public Material autumm;
    public Material winter;
    public Material summer;

    public GameObject map;
    public GameObject buildings;

    float timer = 0.0f;
    float timer2 = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        skybox_1 = Resources.Load("Skybox/Skybox_02") as Material;
        skybox_2 = Resources.Load("Skybox/Skybox_032") as Material;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 15.0f)
        {
            RenderSettings.skybox = skybox_1;
            RenderSettings.skybox.SetFloat("_Rotation", 0.5f * Time.time);

        }

        timer2 += Time.deltaTime;


            ChangeStation();

    }

    public void ChangeStation()
    {
       

        if (timer2 >= 60)
        {
            if (actual_season == seasons.Spring)
                actual_season = seasons.Summer;
            else if (actual_season == seasons.Summer)
                actual_season = seasons.Autum;
            else if (actual_season == seasons.Autum)
                actual_season = seasons.Winter;
            else if (actual_season == seasons.Winter)
                actual_season = seasons.Spring;
           
            foreach (Transform child in map.transform)
            {
                foreach (Transform child2 in child)
                {
                    if (child2.GetComponent<Renderer>() != null)
                    {
                        if (actual_season == seasons.Winter)
                            child2.GetComponent<Renderer>().material = winter;
                        else if (actual_season == seasons.Spring)
                            child2.GetComponent<Renderer>().material = summer;
                        else if (actual_season == seasons.Summer)
                            child2.GetComponent<Renderer>().material = summer;
                        else if (actual_season == seasons.Autum)
                            child2.GetComponent<Renderer>().material = autumm;
                    }
                }
                
            }
            foreach (Transform child in buildings.transform)
            {
                foreach (Transform child2 in child)
                {
                    if (child2.GetComponent<Renderer>() != null)
                    {
                        if (actual_season == seasons.Winter)
                            child2.GetComponent<Renderer>().material = winter;
                        else if (actual_season == seasons.Spring)
                            child2.GetComponent<Renderer>().material = summer;
                        else if (actual_season == seasons.Summer)
                            child2.GetComponent<Renderer>().material = summer;
                        else if (actual_season == seasons.Autum)
                            child2.GetComponent<Renderer>().material = autumm;
                    }


                }
               
            }
           

            timer2 = 0;
        }
       
    }
}
