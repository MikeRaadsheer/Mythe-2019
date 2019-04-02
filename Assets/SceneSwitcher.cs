using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneSwitcher : MonoBehaviour
{
    // Combat.
    public Action EnteredWorld; // Yells EnteredWorld when combat is over.

    // Components.
    private EnemyController[] _ec;
    private Swarm _swarm;

    private GameObject _player;
    private DataManager _dataManager;
    private enum _STATES { WIN, LOSE };
    private Enemies _enemies;
    private CombatState _combatState;

    private string currentScene;

    private bool isDefeated = false;
    
    private void Start()
    {
        _ec = FindObjectsOfType<EnemyController>();
        _swarm = FindObjectOfType<Swarm>();

        for (int i = 0; i < _ec.Length; i++)
        {
            if (_ec[i] != null) _ec[i].EnteredCombat += SwitchToCombatScene;
        }

        _player = GameObject.FindGameObjectWithTag("Player");
        _dataManager = FindObjectOfType<DataManager>();

    }

    private void Update()
    {
        var scene = currentScene;

        currentScene = SceneManager.GetActiveScene().name;

        if(scene != currentScene && currentScene == "Combat")
        {
            _combatState = FindObjectOfType<CombatState>();
            _combatState.LoadWorld += SwitchToWorldScene;
        }

    }

    void LoadCombatScene()
    {
        SceneManager.LoadScene("Combat");
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
        _combatState.SetEnemyState("Win");

        _dataManager.SaveAll();

        SceneManager.LoadScene("Map");
    }
}
