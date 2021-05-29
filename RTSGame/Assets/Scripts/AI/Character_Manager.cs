using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character_Manager : MonoBehaviour
{
    public enum Character { None, Soldier, WoodCutter, Minner, Mage, Farmer };
    public enum Gender { Male, Female, None };
    public Character work_type = Character.None;
    public Gender gender = Gender.None;

    public int HP = 100;
    public bool alive = true;

    public NavMeshAgent agent;

    public bool update_work = false;
    public Animator m_Animator;
    public bool has_to_move = false;

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
        ResetVillager();

      


        Debug.Log(new_work);
        if (new_work == "None")
        {
            this.GetComponent<None_work>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.None;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/None_work") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);


            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/None_work") as RuntimeAnimatorController;
                this.transform.GetChild(8).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

            }
        }
        if (new_work == "Woodcutter")
        {
            this.GetComponent<Woodcutter>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.WoodCutter;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Wood") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_02_A");
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Wood") as RuntimeAnimatorController;
                this.transform.GetChild(8).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);
                this.transform.GetChild(8).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_03_A");
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
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Minner") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_03_A");
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Minner") as RuntimeAnimatorController;
                this.transform.GetChild(8).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);
                this.transform.GetChild(8).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");

            }
        }
        if (new_work == "Farmer")
        {
            this.GetComponent<Farmer>().enabled = true;
            this.GetComponent<Character_Manager>().work_type = Character.Farmer;
            if (gender == Gender.Female)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Farmer") as RuntimeAnimatorController;
                this.transform.GetChild(3).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_04_A");
                this.transform.GetChild(3).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Farmer") as RuntimeAnimatorController;
                this.transform.GetChild(8).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);
                this.transform.GetChild(8).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_02_A");

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
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<None_work>().enabled = false;
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Mage") as RuntimeAnimatorController;
                this.transform.GetChild(5).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_03_A");
                this.transform.GetChild(5).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<None_work>().enabled = false;
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Mage") as RuntimeAnimatorController;
                this.transform.GetChild(11).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);

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
                    if (child.name != "Root" || child.name !="Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Warrior") as RuntimeAnimatorController;
                this.transform.GetChild(2).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_01_A");
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);
                this.GetComponent<Warrior>().sword.SetActive(true);

            }
            else if (gender == Gender.Male)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "Root" || child.name != "Canvas")
                        child.gameObject.SetActive(false);
                    else if (child.name == "Root")
                        child.gameObject.SetActive(true);
                }
                this.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animators/Warrior") as RuntimeAnimatorController;
                this.transform.GetChild(6).gameObject.SetActive(true);
                this.transform.GetChild(15).gameObject.SetActive(true);
                this.GetComponent<Warrior>().sword.SetActive(true);
                this.transform.GetChild(6).GetComponent<Renderer>().material = (Material)Resources.Load("Materials/Villagers/Polygon_Fantasy_Characters_Mat_01_A");

            }
        }
       
    }

    public void ResetVillager()
    {
        if (this.GetComponent<Character_Manager>().work_type == Character.Soldier)
        {
            this.GetComponent<Warrior>().sword.SetActive(false);
            this.GetComponent<Warrior>().enabled = false;

        }
        else if (this.GetComponent<Character_Manager>().work_type == Character.WoodCutter)
        {
            this.GetComponent<Woodcutter>().axe.SetActive(false);
            this.GetComponent<Woodcutter>().HasResources = false;
            this.GetComponent<Woodcutter>().LeaveResources = false;
            this.GetComponent<Woodcutter>().SetPosition = false;
            this.GetComponent<Woodcutter>().InPosition = false;
            this.GetComponent<Woodcutter>().SetWorkPlace = false;
            this.GetComponent<Woodcutter>().resources = 0;
            this.GetComponent<Woodcutter>().enabled = false;
        }
        else if (this.GetComponent<Character_Manager>().work_type == Character.Minner)
        {
            this.GetComponent<Minner>().pick.SetActive(false);
            this.GetComponent<Minner>().HasResources = false;
            this.GetComponent<Minner>().LeaveResources = false;
            this.GetComponent<Minner>().SetPosition = false;
            this.GetComponent<Minner>().InPosition = false;
            this.GetComponent<Minner>().SetWorkPlace = false;
            this.GetComponent<Minner>().resources = 0;
            this.GetComponent<Minner>().enabled = false;
        }
        else if (this.GetComponent<Character_Manager>().work_type == Character.None)
            this.GetComponent<None_work>().enabled = false;
        else if (this.GetComponent<Character_Manager>().work_type == Character.Mage)
            this.GetComponent<Mage>().enabled = false;
    }
    public bool CheckLife()
    {
        if (HP <= 0)
        {
            alive = false;
            m_Animator.SetBool("IsDying", true);
            agent.Stop();

            return alive;
        }

        return alive;
    }
}
