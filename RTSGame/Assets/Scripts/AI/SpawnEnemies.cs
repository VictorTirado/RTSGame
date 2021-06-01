using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject melee;
    public GameObject range;
    public float timer;
    public int round = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 70)
        {
            if (round == 0)
            {
                Instantiate(melee, transform.parent);
              
               
            }
            if(round == 1)
            {
                Instantiate(melee, transform.parent);
                Instantiate(melee, transform.parent);
                //round++;
                //timer = 0.0f;
            }
            if (round == 2)
            {
                Instantiate(melee, transform.parent);
                Instantiate(melee, transform.parent);
                Instantiate(range, transform.parent);
                //round++;
                //timer = 0.0f;
            }
            round++;
            timer = 0.0f;
        }

    }
}
