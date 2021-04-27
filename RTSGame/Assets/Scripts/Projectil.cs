using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    Rigidbody rb;
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
            Destroy(this.gameObject);

    }
}
