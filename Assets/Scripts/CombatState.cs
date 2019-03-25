using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CombatState : MonoBehaviour
{
	// Combat.
	public Action EnteredWorld; // Yells EnteredWorld when combat is over.

	// Components.
	private EnemyController _ec;
	private Swarm _swarm;

	private GameObject _player;
	private DataManager _dataManager;
    private enum _STATES { WIN, LOSE };
    private Enemies _enemies;



	private bool isDefeated = false;

	private void Awake()
	{
		_ec = FindObjectOfType<EnemyController>();
		_swarm = FindObjectOfType<Swarm>();
	}

	private void Start()
	{
		if (_ec != null) _ec.EnteredCombat += SwitchToCombatScene;
		if (_swarm != null) _swarm.EnemyDefeated += TheEnemyIsDead;
		_player = GameObject.FindGameObjectWithTag("Player");
		_dataManager = FindObjectOfType<DataManager>();

	}

	private void Update()
	{
        if (isDefeated)
        {
            Invoke("SwitchToWorldScene", 3f);
        }
	}

	private void TheEnemyIsDead()
	{
		isDefeated = true;
	}

	private void SwitchToCombatScene()
    {
        var player = _dataManager.GetData<PlayerStats>("player");
        
        player.pos.x = _player.transform.position.x;
        player.pos.y = _player.transform.position.y;
        player.pos.z = _player.transform.position.z;

        _dataManager.SaveAll();

        Invoke("LoadCombatScene", 0.1f);
    }

	private void SwitchToWorldScene()
    {
        SetEnemyState(_STATES.WIN);

        _dataManager.SaveAll();

        SceneManager.LoadScene("Map");
    }

	void LoadCombatScene()
    {
        _dataManager.SaveAll();
        SceneManager.LoadScene("Combat");
	}

    void SetEnemyState(_STATES state)
    {
        var enemies = _dataManager.GetData<Enemies>("enemies");


        switch (state)
        {
            case _STATES.WIN:
                for (int i = 0; i < 5; i++)
                {
                    if (enemies.states[i].isFighting)
                    {
                        enemies.states[i].isFighting = false;
                        enemies.states[i].isAlive = false;
                    }
                }
                break;
            case _STATES.LOSE:
                for (int i = 0; i < 5; i++)
                {
                    if (enemies.states[i].isFighting)
                    {
                        enemies.states[i].isFighting = false;
                        enemies.states[i].isAlive = true;
                    }
                }
                break;
            default:
                break;
        }
    }

}
