using UnityEngine;
using System.IO;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;

    public int highScore;
    public string highScoreName;
    public int playerScore;
    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public int playerScore;
        public string playerName;
        public string highScoreName;
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerScore = playerScore;
        data.playerName = playerName;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerScore = data.playerScore;
            playerName = data.playerName;
            highScoreName = data.highScoreName;
        }
    }
    public void ChangeName(string name)
    {
        playerName = name;
        Debug.Log(playerName);
    }
}
