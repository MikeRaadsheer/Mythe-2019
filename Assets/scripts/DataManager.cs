﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    private string inventoryFileName = "inventory.json";
    private string playerPath;
    private string playerFileName = "player.json";

    public LoadData loadData;
    public SaveData saveData;

    public Inventory inventory;
    public Enemy enemy;
    public InventoryPlayerStats player;

    void Awake()
    {
        loadData = GetComponent<LoadData>();
        saveData = GetComponent<SaveData>();

        playerPath = Application.dataPath + "/gameData/player/";


        inventory = loadData.GetGameData<Inventory>(playerPath, inventoryFileName);
        player = loadData.GetGameData<InventoryPlayerStats>(playerPath, playerFileName);

    }

    public void SaveAll()
    {
        saveData.SetGameData(playerPath, inventoryFileName, inventory);
        saveData.SetGameData(playerPath, playerFileName, player);
    }

    public void Save(string type)
    {
        switch (type)
        {
            case "player":
                saveData.SetGameData(playerPath, "player.json", player);
                break;
            case "inventory":
                saveData.SetGameData(playerPath, "inventory.json", inventory);
                break;
        }
    }

    public T GetData<T>(string dataName)
    {
        var result = (T)this.GetType().GetField(dataName).GetValue(this);

        if (result != null) return result;

        Debug.LogError("The data for: " + dataName + " was empty!");
        return default(T);
    }

    public void SetData(string path, string fileName, object data)
    {
        saveData.SetGameData(path, fileName, data);
    }

}
