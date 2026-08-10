using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    private int maxLives = 3;
    public TextMeshProUGUI livesText;    
    private Vector3 spawnPosition = new Vector3(0f, 1f, -26.89f);  //set spawn point    
    private int currentLives;

    private Enemy[] allEnemies;

    void Start()
    {
        //set current lives to 3 and diplays on UI
        currentLives = maxLives;
        UpdateUI();
        allEnemies = FindObjectsOfType<Enemy>();   
    }

    //public function so can be accessed when taking damage 
    public void TakeDamage()
    {
        //reduce lives by 1 and update UI
        currentLives--;
        UpdateUI();

        // send player to start when hit
        transform.position = spawnPosition;

        //apply to all enemies to reset their position
        foreach (Enemy enemy in allEnemies)
        {
            enemy.ResetPosition();
        }

        //Game over condition
        if (currentLives <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    //update UI function
    void UpdateUI()
    {
        livesText.text = "Lives: " + currentLives;
    }
}
