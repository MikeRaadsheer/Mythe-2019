using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour 
{

    public Action<int> hpChanged;

    public PlayerStats player;

    private CombatTurn combat;
    private Dialogue dialogue;
    private Swarm target;
    private ButtonUpdater buttons;

    private DataManager dataManager;
    private Inventory inv;

    private bool waitToAttack = false;
    private bool takeTurn = false;
    private bool returnToItem = false;

    private void Start()
    {
        buttons = FindObjectOfType<ButtonUpdater>();
        target = FindObjectOfType<Swarm>();

        //player = new PlayerStats("Player", 100, 2, 0, 1);
        dataManager = FindObjectOfType<DataManager>();
        dialogue = dataManager.GetDialogue();
        combat = FindObjectOfType<CombatTurn>();
        player = dataManager.GetData<PlayerStats>("player");
        inv = dataManager.GetData<Inventory>("inventory");
        gameObject.name = player.name;

        player.pos.x = transform.position.x;
        player.pos.y = transform.position.y;
        player.pos.z = transform.position.z;

        //dataManager.SetData(Application.dataPath + "/gameData/player/", "player.json", player);

    }

    private void Update()
    {
        waitToAttack = dialogue.GetTyping();

        if (Input.anyKeyDown && !waitToAttack && takeTurn)
        {
            waitToAttack = false;
            takeTurn = false;
            buttons.SetEvtBar(EvtBarStates.BUTTONS);
            buttons.SetMenu(ButtonStates.DEFAULT);
        }

        if (Input.anyKeyDown && !waitToAttack && returnToItem)
        {
            returnToItem = false;
            buttons.SetEvtBar(EvtBarStates.BUTTONS);
            buttons.SetMenu(ButtonStates.ITEM);
        }
    }

    public void TakeDamage(AttackTypes type, int dmg)
    {
        switch (type)
        {
            case AttackTypes.FIRE:
                dmg *= 2;
                break;
        }

        player.hp -= dmg;

        if (player.hp <= 0)
        {
            player.hp = 0;
            dialogue.SetText(("You died").ToUpper());
            Destroy(gameObject, 1f);
        }
        else
        {
            dialogue.SetText(("You took " + dmg.ToString() + " damage!").ToUpper());
            waitToAttack = false;
        }

        if(hpChanged != null) hpChanged(player.hp);

        takeTurn = true;
    }

    public void Heal()
    {
        if (inv.items.hpPotion.ammount <= 0)
        {
            buttons.SetEvtBar(EvtBarStates.DIALOGUE);
            dialogue.SetText(("You can't heal anymore!\n Your potions have run out...").ToUpper());
            returnToItem = true;
            return;
        }

        buttons.SetEvtBar(EvtBarStates.DIALOGUE);
        inv.items.hpPotion.ammount--;

        var ammount = inv.items.hpPotion.lvl * 10;

        player.hp += ammount;
        dialogue.SetText(("You gained " + ammount.ToString() + " hp!").ToUpper());
        combat.EnemyTurn();
    }

    public void Attack(AttackTypes type)
    {
        target.TakeDamage(type, player.att);
    }

    public string GetName()
    {
        return player.name;
    }

    public int GetHp()
    {
        return player.hp;
    }

    public int GetLvl()
    {
        return player.lvl;
    }
}
