using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour {

	private string playerFileName = "player.json";
    private string inventoryFileName = "inventory.json";
    private string enemiesFileName = "enemies.json";
	private string playerPath;
	private string enemyPath;

    public Dialogue dialogue;

    public LoadData loadData;
    public SaveData saveData;

    public Inventory inventory;
    public Enemies enemies;
    public PlayerStats player;

    private void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
        if(SceneManager.GetActiveScene().name == "Combat") GameObject.Find("Dialogue").SetActive(false);
    }

    void Awake() {
        loadData = GetComponent<LoadData>();
        saveData = GetComponent<SaveData>();

		playerPath = Application.dataPath + "/gameData/player/";
		enemyPath = Application.dataPath + "/gameData/enemy/";

		//var enemies = new Enemies();
		//File.WriteAllText(enemyPath + enemiesFileName, JsonUtility.ToJson(enemies));

		enemies = loadData.GetGameData<Enemies>(enemyPath, enemiesFileName);

        inventory = loadData.GetGameData<Inventory>(playerPath, inventoryFileName);

        player = loadData.GetGameData<PlayerStats>(playerPath, playerFileName);

    }

    public void SaveAll() {
        saveData.SetGameData(playerPath, inventoryFileName, inventory);
        saveData.SetGameData(playerPath, playerFileName, player);
        saveData.SetGameData(enemyPath, enemiesFileName, enemies);
    }

    public void Save(string type) {
        switch(type) {
            case "player":
            saveData.SetGameData(playerPath, "player.json", player);
            break;
            case "inventory":
            saveData.SetGameData(playerPath, "inventory.json", inventory);
            break;
        }
    }

    public T GetData<T>(string dataName) {
        var result = (T)this.GetType().GetField(dataName).GetValue(this);

        if(result != null)
            return result;

        Debug.LogError("The data for: " + dataName + " was empty!");
        return default(T);
    }

    public void SetData(string path, string fileName, object data) {
        saveData.SetGameData(path, fileName, data);
    }

    public Dialogue GetDialogue() {
        return dialogue;
    }

}