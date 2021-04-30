using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillagers : MonoBehaviour
{

    float timer = 0.0f;

    public GameObject villager = null;
    public GameObject spawn_point = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=120- 120 *GameObject.Find("Resources_manager").GetComponent<Resources_Manager>().hapiness*0.1f)
        {
            var villager_fake = Instantiate(villager, spawn_point.transform);
            villager_fake.transform.position = spawn_point.transform.position;
            villager_fake.transform.parent = GameObject.Find("Villagers").transform;
            timer = 0.0f;
        }
    }
}
