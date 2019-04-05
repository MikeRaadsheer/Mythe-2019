using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class EnemyController : MonoBehaviour
{
	private bool canInteract, isInteracting, loadedCombat;

    public Action EnteredCombat; // Yells EnteredCombat if player starts combat.

    private DataManager _dataManager;
    private EnemyEnabler _enabler;

	private void Start()
	{
		loadedCombat = false;
		isInteracting = false;
        _dataManager = FindObjectOfType<DataManager>();
        _enabler = GetComponent<EnemyEnabler>();

        var _enemies = _dataManager.GetData<Enemies>("enemies");

        var _id = _enabler.GetId();

        if(SceneManager.GetActiveScene().name == "World")
        {
            for (int i = 0; i < _enemies.states.Length; i++)
            {
                if (_enemies.states[i].ID == _id)
                {
                    _enemies.states[i].isFighting = false;
                }
            }
        }
	}

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            canInteract = true;
            Invoke("LoadCombat", 0.1f);
        }

    }


    private void OnTriggerStay(Collider other) // If player stays inside..
	{
		if (other.tag == "Player") canInteract = true;
	}

	private void OnTriggerExit(Collider other) // If player exits..
	{
		if (other.tag == "Player") canInteract = false;
	}

	private void Update()
	{
		if (canInteract) if (Input.GetKeyDown(KeyCode.E)) isInteracting = true;

		if (isInteracting && !loadedCombat) LoadCombat();		
	}

	private void LoadCombat()
	{

        var _enemies = _dataManager.GetData<Enemies>("enemies");

        int _id = _enabler.GetId();
        

        for (int i = 0; i < _enemies.states.Length; i++)
        {
            if (_enemies.states[i].ID == _id)
            {
                _enemies.states[i].isFighting = true;
            }
        }

        if (EnteredCombat != null) EnteredCombat(); 
    }

    private void OnDisable()
    {
        CancelInvoke("LoadCombat");
    }
}
