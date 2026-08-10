using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOver;
    public TextMeshProUGUI loseFinalScore;
    public GameObject gameWin;
    public TextMeshProUGUI winFinalScore;
    private string saveFileName = "MazeMuncherHighScore.json";
    private GameData currentData;
    public TextMeshProUGUI loseDifferenceScore;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadHighScore();
    }

    //Set Scene to Win UI , freezes time. Saved high score.
    public void GameWin()
    {
        gameWin.SetActive(true);
        Time.timeScale = 0f;

        int finalScore = ScoreManager.Instance.FinalScore();

        winFinalScore.text = "Final Score: " + finalScore;

        if (currentData == null)
        currentData = new GameData();

        //if final score is higher than the saved score.
        if (finalScore > currentData.highScore)
        {
            currentData.highScore = finalScore;
            Debug.Log("NEW HIGH SCORE! : " + finalScore);
            SaveHighScore(); 
        }
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;

        int finalScore = ScoreManager.Instance.FinalScore();

        loseFinalScore.text = "Final Score: " + finalScore;

        if (currentData == null)
        currentData = new GameData();

        //difference between final score and the high score for the difference between them
        int differenceScore = currentData.highScore - finalScore;

        if (differenceScore < 0)
        {
            loseDifferenceScore.text = "Congratulations! You Got a New High Score!";
        }
        else
        {
            loseDifferenceScore.text = "You were only " + differenceScore + " points away from the high score!";
        }

        if (finalScore > currentData.highScore)
        {
            currentData.highScore = finalScore;
            Debug.Log("NEW HIGH SCORE! : " + finalScore);
            SaveHighScore();
        }

    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    public void SaveHighScore()
    {
        if (currentData == null)
        currentData = new GameData();

        //converts high score into json string
        string json = JsonUtility.ToJson(currentData);

        //build file path
        string savePath = Path.Combine(Application.persistentDataPath, saveFileName);

        //writes the json string to the file
        File.WriteAllText(savePath, json);

        Debug.Log("Game Save Path:  " + savePath);
    }

    public int LoadHighScore()
    {
        string savePath = Path.Combine(Application.persistentDataPath, saveFileName);

        //check if file exists
        if (File.Exists(savePath))
        {
            //read json string from file
            string json = File.ReadAllText(savePath);

            //conver json back to GameData
            currentData = JsonUtility.FromJson<GameData>(json);

            return currentData.highScore;
        }
        else
        {
            Debug.LogWarning("No Save File Found");
            return 0;
        }
    }
    
}
