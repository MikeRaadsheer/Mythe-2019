using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour
{
    public GameObject buttons;
    public GameObject dialogue;

    public Swarm target;
    private Player player;
    
    public Text txtLT;
    public Text txtLB;
    public Text txtRT;
    public Text txtRB;

    public Dialogue dialogueSystem;

    private ButtonStates menuState;

    void Start()
    {
        player = FindObjectOfType<Player>();
        menuState = ButtonStates.DEFAULT;
        SetMenu(menuState);
    }

    public void SetEvtBar(EvtBarStates state)
    {
        switch (state)
        {
            case EvtBarStates.BUTTONS:
                buttons.SetActive(true);
                dialogue.SetActive(false);
                break;
            case EvtBarStates.DIALOGUE:
                buttons.SetActive(false);
                dialogue.SetActive(true);
                break;
        }
    }

    public void SetMenu(ButtonStates state)
    {

        switch (state)
        {
            case ButtonStates.DEFAULT:
                menuState = ButtonStates.DEFAULT;
                txtLT.text = "ATTACK";
                txtLB.text = "ITEM";
                txtRT.text = ""/*SKIP*/;
                txtRB.text = ""/*RUN*/;
                break;
            case ButtonStates.ATTACK:
                menuState = ButtonStates.ATTACK;
                txtLT.text = "PUNCH";
                txtLB.text = "STAB";
                txtRT.text = "SLASH";
                txtRB.text = "BACK";
                break;
            case ButtonStates.ITEM:
                menuState = ButtonStates.ITEM;
                txtLT.text = ""/*HP POTION(S): + getter for ammount of potions*/;
                txtLB.text = ""/*STR POTION(S): + getter for ammount of potions*/;
                txtRT.text = ""/* Getters name weapon / fist and damage */;
                txtRB.text = "BACK";
                break;
        }
    }

    public ButtonStates GetMenuState()
    {
        return menuState;
    }
}