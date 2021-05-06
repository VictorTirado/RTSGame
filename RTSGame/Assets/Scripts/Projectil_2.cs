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
            Destroy(this.gameObject);

    }
}
