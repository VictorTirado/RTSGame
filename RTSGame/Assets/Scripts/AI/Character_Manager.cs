using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character_Manager : MonoBehaviour
{
    public enum Character { None, Soldier, WoodCutter, Minner, Mage };
    public enum Gender { Male, Female, None };
    public Character work_type = Character.None;
    public Gender gender = Gender.None;


    public NavMeshAgent agent;

    public bool update_work = false;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        SetGender();
        work_type = Character.None;
        m_Animator = transform.GetComponent<Animator>();
        SetWork();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void SetWork()
    {
        //MALE
        if(work_type == Character.None && gender == Gender.Male)
        {
            this.transform.GetChild(8).gameObject.SetActive(true);
           
        }
      

        //FEMALE
        if (work_type == Character.None && gender == Gender.Female)
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
           // m_Animator.SetBool("isWalking", false);
        }


    }


    private void SetGender()
    {
       int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            Debug.Log(rand);
            this.gender = Gender.Male;
        }
        else if(rand == 1)
        {
            Debug.Log(rand);
            this.gender = Gender.Female;
        }

        m_Animator.SetBool("isWalking", false);

    }

    public void UpdateWork(string new_work)
    {
        Debug.Log(new_work);
        if (new_work == "None")
        {
            this.GetComponent<None_work>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.None;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/None_work") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");
                this.transform.GetChild(3).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/None_work") as RuntimeAnimatorController;
                this.transform.GetChild(8).gameObject.SetActive(true);

            }
        }
        if (new_work == "Woodcutter")
        {
            this.GetComponent<Wood_work>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.WoodCutter;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Wood") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_02_A");
                this.transform.GetChild(3).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Wood") as RuntimeAnimatorController;
                this.transform.GetChild(5).gameObject.SetActive(true);

            }
        }
        if (new_work == "Minner")
        {
            this.GetComponent<Minner>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.Minner;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Minner") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_02_A");
                this.transform.GetChild(3).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Minner") as RuntimeAnimatorController;
                this.transform.GetChild(5).gameObject.SetActive(true);

            }
        }
        if (new_work == "Mage")
        {
            // IMPORTANTE LINEA 247
            this.GetComponent<Character_Manager>().work_type = Character.Mage;
            this.GetComponent<Mage>().enabled = true;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<None_work>().enabled = false;
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Mage") as RuntimeAnimatorController;
                this.transform.GetChild(5).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");
                this.transform.GetChild(5).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<None_work>().enabled = false;
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Mage") as RuntimeAnimatorController;
                this.transform.GetChild(11).gameObject.SetActive(true);

            }
        }

        if (new_work == "Soldier")
        {
            
            this.GetComponent<Warrior>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.Soldier;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Warrior") as RuntimeAnimatorController;
                this.transform.GetChild(5).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");
                this.transform.GetChild(2).gameObject.SetActive(true);
               
            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Warrior") as RuntimeAnimatorController;
                this.transform.GetChild(6).gameObject.SetActive(true);
               
            }
        }
       
    }
}
