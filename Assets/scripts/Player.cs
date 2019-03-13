using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{


    //private PlayerStats player;
    public PlayerStats player;

    public Dialogue dialogue;
    private Swarm target;
    private ButtonUpdater buttons;

    private DataManager dataManager;

    private bool waitToAttack = false;
    private bool takeTurn = false;

    private void Start()
    {
        buttons = FindObjectOfType<ButtonUpdater>();
        target = FindObjectOfType<Swarm>();

        //player = new PlayerStats("Player", 100, 2, 0, 1);
        dataManager = FindObjectOfType<DataManager>();
        player = dataManager.GetData<PlayerStats>("player");
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

        takeTurn = true;
    }

    public void Heal(int ammount)
    {
        player.hp += ammount;
        dialogue.SetText(("You gained " + ammount.ToString() + " hp!").ToUpper());
        target.TakeTurn();
    }

    public void SkipTurn()
    {
        buttons.SetEvtBar(EvtBarStates.DIALOGUE);
        dialogue.SetText(("You skipped your turn!").ToUpper());
        target.TakeTurn();
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
