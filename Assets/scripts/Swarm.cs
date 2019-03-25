using UnityEngine;
using System;

public class Swarm : MonoBehaviour
{

    public Action<int> hpChanged;

    private DataManager _dataManager;
    private Dialogue dialogue;
    private Enemy swarm = new Enemy("Swarm", 10, 1, 0, AttackTypes.FIRE, AttackTypes.STAB, 1);
    private Player target;

	private bool waitToAttack = false;
    private bool takeTurn = false;
	private bool clickToExit = false;

	public Action EnemyDefeated;


    private void Start()
    {
        _dataManager = FindObjectOfType<DataManager>();
        swarm.att = (int)Mathf.Sqrt(swarm.lvl);
        target = FindObjectOfType<Player>();
        dialogue = _dataManager.GetDialogue();

        var _enemies = _dataManager.GetData<Enemies>("enemies");

        for (int i = 0; i < _enemies.states.Length; i++)
        {
            if (_enemies.states[i].isFighting)
            {
                swarm.hp = _enemies.states[i].hp;
            }
        }

    }

    private void Update()
    {
        waitToAttack = dialogue.GetTyping();

        if (Input.anyKeyDown && !waitToAttack && takeTurn)
        {
            waitToAttack = false;
            takeTurn = false;
            target.TakeDamage(AttackTypes.PUNCH, swarm.att);
        }
    }

    public void TakeDamage(AttackTypes type, int dmg)
    {
        switch (type)
        {
            case AttackTypes.FIRE:
                dmg *= 2;
                break;
            case AttackTypes.STAB:
                dmg = 0;
                break;
        }

        swarm.hp -= dmg;
        
        if (swarm.hp <= 0)
        {
			swarm.hp = 0;
			KillThisEnemy();
		}
		else
        {
            dialogue.SetText(("You dealt " + dmg.ToString() + " damage!").ToUpper());
            waitToAttack = false;
        }

        if (hpChanged != null) hpChanged(swarm.hp);

        takeTurn = true;

    }

    public void SetTakeTurn(bool val)
    {
        takeTurn = val;
    }

    public string GetName()
    {
        return swarm.name;
    }

    public int GetHp()
    {
        return swarm.hp;
    }

    public int GetLvl()
    {
        return swarm.lvl;
    }
	
	private void KillThisEnemy()
	{
		clickToExit = true;
		dialogue.SetText(("You killed the " + swarm.name).ToUpper());
        EnemyDefeated(); // Yell the swarm has died.
		Destroy(gameObject, 1f);
	}

    private void OnDestroy()
    {
        var _enemies = _dataManager.GetData<Enemies>("enemies");

        for (int i = 0; i < _enemies.states.Length; i++)
        {
            if (_enemies.states[i].isFighting)
            {
                _enemies.states[i].hp = swarm.hp;
            }
        }
    }
}
