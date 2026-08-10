using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject instructionUI;
    public TextMeshProUGUI allTimeHighScore;

    private string saveFileName = "MazeMuncherHighScore.json";

    void Start()
    {
        menuUI.SetActive(true);
        instructionUI.SetActive(false);

        int highScore = LoadHighScore();
        
        allTimeHighScore.text = "High Score: " + highScore;


    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GotoInstructions()
    {
        menuUI.SetActive(false);
        instructionUI.SetActive(true);
    }

    public void GoToMenu()
    {
        instructionUI.SetActive(false);
        menuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private int LoadHighScore()
    {
        string path = Path.Combine(Application.persistentDataPath, saveFileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data.highScore;            
        }
        else
        {
            return 0;
        }
    }
}
