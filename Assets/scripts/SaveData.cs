using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour {

    public void SetGameData(string path, string fileName, object data)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("Couldn't find " + fileName + " at:" + path);
            return;
        }

        File.WriteAllText(path, JsonUtility.ToJson(data));
    }
}
