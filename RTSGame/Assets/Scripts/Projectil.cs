using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
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
        rb.velocity = transform.forward * 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject;
            Hit();
            Destroy(this.gameObject);

        }

    }
    public void Hit()
    {
        int dmg = 10;
        if (enemy.GetComponent<enemy>() != null)
            enemy.GetComponent<enemy>().HP -= dmg;
      
        else if (enemy.GetComponent<Enemy_melee>() != null)
            enemy.GetComponent<Enemy_melee>().HP -= dmg;



    }
}

