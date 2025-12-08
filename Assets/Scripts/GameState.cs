using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public int totalScore;
    public int currentLevel;

    // Map level number to its data
    public Dictionary<int, LevelData> levels = new Dictionary<int, LevelData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadState();
    }

    #region Save/Load

    public void SaveState()
    {
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.SetInt("currentLevel", currentLevel);

        // Save levels as JSON string
        string json = JsonUtility.ToJson(new LevelDataContainer(levels));
        PlayerPrefs.SetString("levels", json);

        PlayerPrefs.Save();
    }

    public void LoadState()
    {
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        string json = PlayerPrefs.GetString("levels", "");
        if (!string.IsNullOrEmpty(json))
        {
            LevelDataContainer container = JsonUtility.FromJson<LevelDataContainer>(json);
            levels = container.ToDictionary();
        }
        else
        {
            levels = new Dictionary<int, LevelData>();
        }
    }

    public void ResetState()
    {
        PlayerPrefs.DeleteKey("totalScore");
        PlayerPrefs.DeleteKey("currentLevel");
        PlayerPrefs.DeleteKey("levels");

        totalScore = 0;
        currentLevel = 1;
        levels.Clear();
    }
    #endregion



    public void setLevelCompleted(int levelNumber, float completionTime)
    {
        if (!levels.ContainsKey(levelNumber))
        {
            levels[levelNumber] = new LevelData(true, completionTime);
        }
        else
        {
            LevelData data = levels[levelNumber];
            data.completed = true;
            if (data.bestTime == 0f || completionTime < data.bestTime)
            {
                data.bestTime = completionTime;
            }
            levels[levelNumber] = data;
        }

        SaveState();
    }


    public LevelData GetLevelData(int levelNumber)
    {
        if (levels.ContainsKey(levelNumber))
        {
            return levels[levelNumber];
        }
        return new LevelData();
    }
}



[System.Serializable]
public class LevelData
{
    public bool completed = false;
    public float bestTime = 0f;

    public LevelData() { }

    public LevelData(bool completed, float bestTime)
    {
        this.completed = completed;
        this.bestTime = bestTime;
    }
}


[System.Serializable]
public class LevelDataContainer
{
    public List<int> keys = new List<int>();
    public List<LevelData> values = new List<LevelData>();

    public LevelDataContainer(Dictionary<int, LevelData> dict)
    {
        foreach (var kvp in dict)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    public Dictionary<int, LevelData> ToDictionary()
    {
        var dict = new Dictionary<int, LevelData>();
        for (int i = 0; i < keys.Count; i++)
            dict[keys[i]] = values[i];
        return dict;
    }
}