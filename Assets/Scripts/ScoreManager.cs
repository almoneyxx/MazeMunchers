using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;
    private int score;
    private int totalOrbs;
    private int orbsCollected;

    void Awake()
    {
        //ensres only one score manager is active at once
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        totalOrbs = FindObjectsOfType<Orb>().Length;
    }

    //function to add points to score and update UI , can be accessed by other scripts
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
        orbsCollected++;
        if (orbsCollected >= totalOrbs)
        {
            GameManager.Instance.GameWin();
        }
    }

    public int FinalScore()
    {
        return score;
    }
    
    
}
