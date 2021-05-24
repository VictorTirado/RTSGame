using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWork : MonoBehaviour
{
    public Workers_Manager wm;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
      
        wm = GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        //if (this.gameObject.name == "None")
        //    parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);

        //else if (this.gameObject.name =="Minner")
        //{
        //    if(wm.current_minners < wm.minners_capacity)
        //        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        //}
        //else if (this.gameObject.name == "Woodcutter")
        //{
        //    if (wm.current_woodcutters < wm.woodcutters_capacity)
        //        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        //}
        //else if (this.gameObject.name == "Soldier")
        //{
        //    if (wm.current_soldiers < wm.soldiers_capacity)
        //        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        //}
        //else if (this.gameObject.name == "Mage")
        //{
        //    if (wm.current_mages < wm.mages_capacity)
        //        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        //}
        parent.GetComponent<Character_Manager>().UpdateWork(this.gameObject.name);
        GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().ResetWorkers();
        GameObject.Find("Workers_Manager").GetComponent<Workers_Manager>().UpdateWorkers();








        parent.GetComponent<Character_Manager>().update_work = true;
        GameObject.Find("Controller (right)").GetComponent<GetPeople2>().set_people = true;
    }
}
