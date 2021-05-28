using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVillagers : MonoBehaviour
{

    public float timer = 0.0f;

    public GameObject villager = null;
    public GameObject spawn_point = null;
    // Start is called before the first frame update
    void Start()
    {
        if (ChangeMap.naming == "Sazed" || ChangeMap.naming == "Breeze")
            Instantiate(Resources.Load("Prefabs/People/Sazed"));
        else if (ChangeMap.naming == "Vin")
            Instantiate(Resources.Load("Prefabs/People/Vin"));
        var vill_fake_1 = Instantiate(villager, spawn_point.transform);
        vill_fake_1.transform.position = spawn_point.transform.position;
        vill_fake_1.transform.parent = GameObject.Find("Villagers").transform;
        var vill_fake_2 = Instantiate(villager, spawn_point.transform);
        vill_fake_2.transform.position = spawn_point.transform.position;
        vill_fake_2.transform.parent = GameObject.Find("Villagers").transform;
        var vill_fake_3 = Instantiate(villager, spawn_point.transform);
        vill_fake_3.transform.position = spawn_point.transform.position;
        vill_fake_3.transform.parent = GameObject.Find("Villagers").transform;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameObject.Find("Resources_manager").GetComponent<Resources_Manager>().villagers < GameObject.Find("Resources_manager").GetComponent<Resources_Manager>().max_villagers)
        {
            if (timer >= 45 - 45 * GameObject.Find("Resources_manager").GetComponent<Resources_Manager>().hapiness * 0.1f)
            {
                var villager_fake = Instantiate(villager, spawn_point.transform);
                villager_fake.transform.position = spawn_point.transform.position;
                villager_fake.transform.parent = GameObject.Find("Villagers").transform;
                GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().current_none_workers += 1;
                timer = 0.0f;
            }
        }
    }
}
