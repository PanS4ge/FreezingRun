using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveFiles : MonoBehaviour
{
    public string filePath;
    public DataHolder dh;

    // Save data
    void Start(){
        filePath = Application.persistentDataPath + "/save.frn";
    }
    public void DoSave(){
        File.WriteAllText(filePath, JsonUtility.ToJson(dh.data));
    }

    public DataHolder.PlayerData getPlayerFromSaveFile(){
        try {
            return JsonConvert.DeserializeObject<DataHolder.PlayerData>(getFileData());
        } catch {
            return new DataHolder.PlayerData();
        }
    }

    public string getFileData(){
        return File.ReadAllText(filePath);
    }
}
