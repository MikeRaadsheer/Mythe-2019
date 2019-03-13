using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Items : MonoBehaviour
{
    [HideInInspector]
    public GameObject ItemManager;

    [HideInInspector]
    public GameObject Weapon;
    [HideInInspector]
    public GameObject Armor;
    [HideInInspector]
    public GameObject Shield;
    [HideInInspector]
    public GameObject Potion;

    public string type;
    public string description;
    public int ID;

    public Sprite Icon;

    [HideInInspector]
    public bool Equipped;
    public bool PickedUp;
    public bool PlayersItem;

    private void Start()
    {
        Equipped = false;

        ItemManager = GameObject.FindWithTag("ItemManager");

        Weapon = GameObject.FindWithTag("Item");
        Armor = GameObject.FindWithTag("Armor");
        Shield = GameObject.FindWithTag("Armor"); 
        Potion = GameObject.FindWithTag("Armor");
    }

    private void Update()
    {
        if (!PlayersItem)
        {
            int AllWeapons = ItemManager.transform.childCount;
            for(int i = 0; i<AllWeapons; i++)
            {
                if(ItemManager.transform.GetChild(1).gameObject.GetComponent<Items>().ID == ID)
                {
                    //AllItems = ItemManager.transform.GetChild(i).gameObject;
                }

            }
        }

        if (Equipped)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Equipped = false;
                if(Equipped == false)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ItemUsage()
    {
        if(type == "Weapon")
        {
            Equipped = true;
        }
        else if(type == "Armor")
        {
            Equipped = true;
        }
        else if(type == "Shield")
        {
            Equipped = true;
        }
        else if(type == "Potion")
        {
            Equipped = true;
        }

    }
   
}
