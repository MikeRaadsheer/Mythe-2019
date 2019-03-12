using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtBarBtn : MonoBehaviour
{
    private ButtonUpdater buttons;
    private Player player;

    private ButtonStates menuState;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        buttons = FindObjectOfType<ButtonUpdater>();
    }

    public void BtnLT()
    {
        menuState = buttons.GetMenuState();
        switch (menuState)
        {
            case ButtonStates.DEFAULT:
                buttons.SetMenu(ButtonStates.ATTACK);
                break;
            case ButtonStates.ATTACK:
                buttons.SetEvtBar(EvtBarStates.DIALOGUE);
                player.attack(AttackTypes.PUNCH);
                break;
            case ButtonStates.ITEM:
                buttons.SetEvtBar(EvtBarStates.DIALOGUE);
                player.takeDamage(AttackTypes.NONE, 10);
                break;
        }
    }
    
    public void BtnLB()
    {
        menuState = buttons.GetMenuState();
        switch (menuState)
        {
            case ButtonStates.DEFAULT:
                buttons.SetMenu(ButtonStates.ITEM);
                break;
            case ButtonStates.ATTACK:
                buttons.SetEvtBar(EvtBarStates.DIALOGUE);
                player.attack(AttackTypes.STAB);
                break;
            case ButtonStates.ITEM:
                /*BOOST ATTACK FOR X AMMOUNT OF TURNS*/
                break;
            default:
                break;
        }
    }
    
    public void BtnRT()
    {
        menuState = buttons.GetMenuState();
        switch (menuState)
        {
            case ButtonStates.DEFAULT:
                /*SKIP TURN*/
                break;
            case ButtonStates.ATTACK:
                buttons.SetEvtBar(EvtBarStates.DIALOGUE);
                player.attack(AttackTypes.SLASH);
                break;
            case ButtonStates.ITEM:
                /*SWITCH WEAPON*/
                break;
            default:
                break;
        }
    }
    
    public void BtnRB()
    {
        menuState = buttons.GetMenuState();
        switch (menuState)
        {
            case ButtonStates.ATTACK:
                buttons.SetMenu(ButtonStates.DEFAULT);
                break;
            case ButtonStates.ITEM:
                buttons.SetMenu(ButtonStates.DEFAULT);
                break;
        }
    }
}
