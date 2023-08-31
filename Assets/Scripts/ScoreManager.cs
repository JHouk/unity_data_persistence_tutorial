using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public int HighScore = 0;
    static public string LeaderName = "";
    static public string PlayerName;

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string LeaderName;
    }

    public void SaveHighScore(){
        SaveData data = new SaveData();
        data.HighScore = ScoreManager.HighScore;
        data.LeaderName = ScoreManager.LeaderName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ScoreManager.HighScore = data.HighScore;
            ScoreManager.LeaderName = data.LeaderName;
        }
    }
}
