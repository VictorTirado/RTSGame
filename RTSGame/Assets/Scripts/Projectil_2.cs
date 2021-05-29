using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil_2 : MonoBehaviour
{
    Rigidbody rb;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
         rb = this.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(enemy.transform.position);
        rb.velocity = transform.forward * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "People")
        {
            enemy = other.gameObject;
            Hit();
            Destroy(this.gameObject);

        }

    }

    public void Hit()
    {
        int dmg = Random.Range(55, 65);

        enemy.GetComponent<Character_Manager>().HP -= dmg;
        //if (enemy.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
        //    enemy.GetComponent<Mage>().HP -= dmg;
        //else if (enemy.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
        //    enemy.GetComponent<Warrior>().HP -= dmg;
        //else
        //    enemy.GetComponent<Character_Manager>().HP -= dmg;

    }
}
