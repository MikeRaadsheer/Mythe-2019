using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour {

    public GameData GetGameData<GameData>(string path, string fileName)
    {
        if (!File.Exists(path + fileName))
        {
            Debug.LogError("Couldn't find " + fileName + " at:" + path + fileName);
            return default(GameData);
        }

        string jsonString = File.ReadAllText(path + fileName);

        GameData data = JsonUtility.FromJson<GameData>(jsonString);

        if(data != null) return data;



        Debug.LogError("Data for " + fileName + " was empty!");
        return default(GameData);
    }
}
