using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public SaveFiles sf;
    [System.Serializable]
    public class PlayerData{
        public string Name;
        public int CoinCount = 50;
        public int Level = 1;
        public int PlacementRanking;
        public Vector3 Trousers = new Vector3(209, 54, 54);
        public Vector3 Body = new Vector3(0, 255, 176);
        public Vector3 Skin = new Vector3(255, 255, 123);
        public Vector4 Ice = new Vector4(0, 189, 255, 103);
        public Vector4 Fire = new Vector4(204, 0, 0, 129);
    }

    public PlayerData data = new PlayerData();

    void Start(){
        data = sf.getPlayerFromSaveFile();
        //data.Trousers = new Vector3(209, 54, 54);
        //data.Body = new Vector3(0, 255, 176);
        //data.Skin = new Vector3(255, 255, 123);
        //data.Ice = new Vector4(0, 189, 255, 103);
        //data.Fire = new Vector4(204, 0, 0, 129);
    }
}
