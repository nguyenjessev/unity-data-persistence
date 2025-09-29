using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public int HighScore { get; set; } = 0;
    public string HighScorePlayerName { get; set; } = "Player";

    public string PlayerName { get; set; } = "Player";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    [System.Serializable]
    public class SaveData
    {
        [field: SerializeField]
        public string PlayerName { get; set; }
        [field: SerializeField]
        public int HighScore { get; set; }
    }

    public void SaveGame()
    {
        SaveData data = new()
        {
            PlayerName = HighScorePlayerName,
            HighScore = HighScore
        };

        string json = JsonUtility.ToJson(data);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.PlayerName;
            HighScore = data.HighScore;
        }
    }
}
