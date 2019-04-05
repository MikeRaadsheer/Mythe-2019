using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombatState : MonoBehaviour
{
    // Combat.
    public Action EnteredWorld; // Yells EnteredWorld when combat is over.
    public Action LoadWorld;

    // Components.
    private EnemyController[] _ec;
    private Swarm _swarm;

    private GameObject _player;
    private DataManager _dataManager;
    private Enemies _enemies;

    private bool isDefeated = false;


    private void Start()
    {
        _ec = FindObjectsOfType<EnemyController>();
        _swarm = FindObjectOfType<Swarm>();

        if (_swarm != null) { _swarm.EnemyDefeated += TheEnemyIsDead; } else { Debug.LogError("Enemy could not be found!"); }

        _player = GameObject.FindGameObjectWithTag("Player");
        _dataManager = FindObjectOfType<DataManager>();

    }

    private void Update()
    {
        if (isDefeated) Invoke("SwitchToWorld", 3f);
    }

    void SwitchToWorld()
    {
        if (LoadWorld == null) Debug.Log("ya Boi");
        LoadWorld();
        
    }

    private void TheEnemyIsDead()
    {
        isDefeated = true;
    }

    public void SetEnemyState(string state)
    {
        var enemies = _dataManager.GetData<Enemies>("enemies");


        switch (state)
        {
            case "Win":
                for (int i = 0; i < 5; i++)
                {
                    if (enemies.states[i].isFighting)
                    {
                        enemies.states[i].isFighting = false;
                        enemies.states[i].isAlive = false;
                    }
                }
                break;
            case "Lose":

                //load checkpoint

                //for (int i = 0; i < 5; i++)
                //{
                //    if (enemies.states[i].isFighting)
                //    {
                //        enemies.states[i].isFighting = false;
                //        enemies.states[i].isAlive = true;
                //    }
                //}
                break;
            default:
                break;
        }
    }

}
