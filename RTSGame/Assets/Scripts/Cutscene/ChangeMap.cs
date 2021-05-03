using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject name;
    static public string naming;
    private void Awake()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(naming);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "book")
        {
            
            naming = other.name;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
