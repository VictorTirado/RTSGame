using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Update_HP : MonoBehaviour
{
    // Start is called before the first frame update
    Image im;

    float HP_Villager = 100.0f;
    float HP_Soldier = 120.0f;
    float HP_Mage = 70.0f;
    void Start()
    {
        im = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.parent.transform.parent.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Mage)
            im.fillAmount = this.transform.parent.parent.GetComponent<Mage>().HP / HP_Mage;
        else if(this.transform.parent.parent.GetComponent<Character_Manager>().work_type == Character_Manager.Character.Soldier)
            im.fillAmount = this.transform.parent.parent.GetComponent<Warrior>().HP /HP_Soldier;
        else
            im.fillAmount = this.transform.parent.transform.parent.GetComponent<Character_Manager>().HP / HP_Villager;

    }
}
