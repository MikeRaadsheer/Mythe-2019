using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string displayName;
    private int hp = 100;
    private int att = 2;
    private int def = 0;
    private int lvl = 1;

    public Dialogue dialogue;
    private Swarm target;
    private ButtonUpdater buttons;

    private bool waitToAttack = false;
    private bool takeTurn = false;

    private void Start()
    {
        displayName = gameObject.name;

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
        }

        hp -= dmg;

        if (hp <= 0)
        {
            hp = 0;
            /*TYPE DIALOGUE UPDATE INFO THEN DIE*/
        }
        else
        {
            dialogue.SetText(("You took " + dmg.ToString() + " damage!").ToUpper());
            waitToAttack = false;
        }

        takeTurn = true;
    }

    public void attack(AttackTypes type)
    {
        target.takeDamage(type, att);
    }

    public string GetName()
    {
        return name;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetLvl()
    {
        return lvl;
    }


}
