using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour {

    public GameData GetGameData<GameData>(string path, string fileName)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("Couldn't find " + fileName + " at:" + path);
            return default(GameData);
        }

        string jsonString = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(jsonString);

        return data;
    }
}
