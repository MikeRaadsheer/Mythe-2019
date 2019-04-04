//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class Slot : MonoBehaviour, IPointerClickHandler
//{
//    public GameObject Item;
//    public Transform SlotIconGO;

//    public string type;
//    public string description;
//    public int ID;

//    public bool Empty;
    
//    public Sprite Icon;

//    public void OnPointerClick(PointerEventData pointerEventData)
//    {
//        UseItem();
//    }

//    private void Start()
//    {
//       SlotIconGO = transform.GetChild(0);
//    }

//    public void UpdateSlot()
//    {
//        SlotIconGO.GetComponent<Image>().sprite = Icon;
//    }

//    public void UseItem()
//    {
//        Item.GetComponent<InventoryItems>().ItemUsage();
//    }
//}
