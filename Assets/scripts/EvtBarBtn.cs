using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvtBarBtn : MonoBehaviour
{
    private ButtonUpdater buttons;
    private Player player;
    private Dialogue dialogue;
    private CombatTurn combat;

    private Inventory inv;
    private DataManager dataManager;

    private ButtonStates menuState;

    private void Start()
    {
        combat = FindObjectOfType<CombatTurn>();
        dataManager = FindObjectOfType<DataManager>();

        player = FindObjectOfType<Player>();
        inv = dataManager.GetData<Inventory>("inventory");

        buttons = FindObjectOfType<ButtonUpdater>();
        dialogue = dataManager.GetDialogue();

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
                player.Attack(AttackTypes.PUNCH);
                break;
            case ButtonStates.ITEM:
                player.Heal();
                break;
            case ButtonStates.DEV_TOOLS:
                dataManager.Save("inventory");
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
                player.Attack(AttackTypes.STAB);
                break;
            case ButtonStates.ITEM:
                /*BOOST ATTACK FOR X AMMOUNT OF TURNS*/
                break;
            case ButtonStates.DEV_TOOLS:
                dataManager.Save("player");
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
                combat.SkipTurn();
                break;
            case ButtonStates.ATTACK:
                buttons.SetEvtBar(EvtBarStates.DIALOGUE);
                player.Attack(AttackTypes.SLASH);
                break;
            case ButtonStates.ITEM:
                /*SWITCH WEAPON*/
                break;
            case ButtonStates.DEV_TOOLS:
                dataManager.SaveAll();
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
            case ButtonStates.DEFAULT:
                buttons.SetMenu(ButtonStates.DEV_TOOLS);
                break;
            case ButtonStates.ATTACK:
                buttons.SetMenu(ButtonStates.DEFAULT);
                break;
            case ButtonStates.ITEM:
                buttons.SetMenu(ButtonStates.DEFAULT);
                break;
            case ButtonStates.DEV_TOOLS:
                buttons.SetMenu(ButtonStates.DEFAULT);
                break;
        }
    }

    void Heal()
    {

    }

}
