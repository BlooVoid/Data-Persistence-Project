using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.IO;
public class MenuUIHandler : MonoBehaviour
{
    //This is the handler of the main menu scene

    [SerializeField] TMP_InputField PlayerNameInput;
    [SerializeField] GameObject warningText;

    private void Start()
    {
        
    }

    public void StartGame()
    {
        if(PlayerNameInput.text != string.Empty)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            warningText.SetActive(true);
        }
    }

    public void SetPlayerName()
    {
        MainManager.Instance.PlayerName = PlayerNameInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void DeleteSavedData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }
}

