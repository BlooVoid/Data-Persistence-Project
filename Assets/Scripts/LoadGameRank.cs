using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class LoadGameRank : MonoBehaviour
{

    //Fields for display the player info

    public TextMeshProUGUI BestPlayerName;


    //Static variables for holding the best player data
    private static int BestScore;
    private static string BestPlayer;


    private void Awake()
    {
        LoadRanking();
    }

    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = $"Best Score - N/A: N/A";
        }
        else
        {
            BestPlayerName.text = $"Best Score - {BestPlayer}: {BestScore}";
        }

    }

    public void LoadRanking()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighiestScore;
            SetBestPlayer();
        }
        else
        {
            BestPlayer = null;
            BestScore = 0;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighiestScore;
        public string TheBestPlayer;
    }
}
