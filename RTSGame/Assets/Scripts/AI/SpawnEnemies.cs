using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject melee;
    public GameObject range;
    float timer;
    int round = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 50)
        {
            if (round == 0)
            {
                Instantiate(melee, transform.parent);
                round++;
                timer = 0.0f;
            }
            if(round == 1 && timer == 0)
            {
                Instantiate(melee, transform.parent);
                Instantiate(melee, transform.parent);
                round++;
                timer = 0.0f;
            }
            if (round == 2 && timer == 0)
            {
                Instantiate(melee, transform.parent);
                Instantiate(melee, transform.parent);
                Instantiate(range, transform.parent);
                round++;
                timer = 0.0f;
            }
        }

    }
}
