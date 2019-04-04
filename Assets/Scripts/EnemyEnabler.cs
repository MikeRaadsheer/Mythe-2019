using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnabler : MonoBehaviour
{
	public int ID;

	private LoadData _dataLoader;

	private void Awake()
	{
		_dataLoader = FindObjectOfType<LoadData>();

		var enemies = _dataLoader.GetGameData<Enemies>(Application.dataPath + "/gameData/enemy/", "enemies.json");

        for (int i = 0; i < 5; i++)
        {
            if (enemies.states[i].ID == ID && !enemies.states[i].isAlive) gameObject.SetActive(false);
        }
    }

    public int GetId()
    {
        return ID;
    }

}
