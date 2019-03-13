using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour {

    public void SetGameData(string path, string fileName, object data)
    {
        if (!File.Exists(path + fileName))
        {
            Debug.LogError("Couldn't find " + fileName + " at:" + path + fileName);
            return;
        } else if (data == null)
        {
            Debug.LogError("Data for" + fileName + " was empty");
            return;
        }

        File.WriteAllText(path + fileName, JsonUtility.ToJson(data));
    }
}
