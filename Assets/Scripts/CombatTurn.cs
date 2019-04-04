using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTurn : MonoBehaviour
{
    private ButtonUpdater buttons;
    private Player player;
    private Swarm target;
    private Dialogue dialogue;


    private Inventory inv;
    private DataManager dataManager;

    private ButtonStates menuState;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        buttons = FindObjectOfType<ButtonUpdater>();
        player = FindObjectOfType<Player>();
        target = FindObjectOfType<Swarm>();
        inv = dataManager.GetData<Inventory>("inventory");
        dialogue = dataManager.GetDialogue();
    }

    public void SkipTurn()
    {
        buttons.SetEvtBar(EvtBarStates.DIALOGUE);
        dialogue.SetText(("You skipped your turn!").ToUpper());
        EnemyTurn();
    }

    public void EnemyTurn()
    {
        target.SetTakeTurn(true);
    }

}
