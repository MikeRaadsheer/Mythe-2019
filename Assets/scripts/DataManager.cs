using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string inventoryFileName = "inventory.json";
    private string inventoryPath;

    public LoadData loadData;
    public SaveData saveData;

    public Inventory inventory;

    void Start()
    {
        loadData = GetComponent<LoadData>();
        saveData = GetComponent<SaveData>();
        

        inventoryPath = Application.dataPath + "/gameData/player/" + inventoryFileName;

        inventory = loadData.GetGameData<Inventory>(inventoryPath, inventoryFileName);

        inventory.items[0].name = "health potion";

        saveData.SetGameData(inventoryPath, inventoryFileName, inventory);

    }
}
