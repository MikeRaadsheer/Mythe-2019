using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

    private PlayerStats player = new PlayerStats("Spirit", 100, 2, 0, 1);

    public Dialogue dialogue;
    private Swarm target;
    private ButtonUpdater buttons;

    private bool waitToAttack = false;
    private bool takeTurn = false;

    private void Start()
    {
        gameObject.name = player.name;

        buttons = FindObjectOfType<ButtonUpdater>();
        target = FindObjectOfType<Swarm>();
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
    }

    public void takeDamage(AttackTypes type, int dmg)
    {
        switch (type)
        {
            case AttackTypes.FIRE:
                dmg *= 2;
                break;
            case AttackTypes.NONE:
                if (dmg > 0) dmg = -dmg; ;
                break;
        }

        player.hp -= dmg;

        if (player.hp <= 0)
        {
            player.hp = 0;
            dialogue.SetText(("You died").ToUpper());
            Destroy(gameObject, 1f);
        }
        else if (dmg > 0)
        {
            dialogue.SetText(("You took " + dmg.ToString() + " damage!").ToUpper());
            waitToAttack = false;
        }
        else if (dmg < 0)
        {
            dmg = -dmg;
            dialogue.SetText(("You gained " + dmg.ToString() + " hp!").ToUpper());
            target.takeDamage(AttackTypes.NONE, 0);
            return;
        }

        takeTurn = true;
    }

    public void attack(AttackTypes type)
    {
        target.takeDamage(type, player.att);
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
