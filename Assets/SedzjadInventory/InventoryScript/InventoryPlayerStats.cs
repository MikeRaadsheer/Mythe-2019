using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPlayerStats : MonoBehaviour
{
    public GameObject ItemManager;

    public int AttackDamage;
    public int Defence;

    public Text AttackDamageText;
    public Text DefenceText;

    public void Start()
    {
        ItemManager = GameObject.FindWithTag("ItemManager");       

    }

    public void OnEquipItem()
    {

    }

}
