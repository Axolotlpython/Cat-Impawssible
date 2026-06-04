using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Chesse Settings")]
    public int cheeseCollected = 0;
    public int cheeseNeededToWin = 5;
    public int pointsleft;

    [Header("UI")]
    public TMP_Text cheeseText;
    public GameObject winPanel;
    public GameObject losePanel;

    [Header("LevelBlocks")]
    public GameObject window;
    public GameObject sewer;
    public GameObject pipe;


    public GameObject Jack;

    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        UpdateCheeseUI();
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    public void AddCheese(int amount)
    {
        if (gameOver) return;

        cheeseCollected += amount;
        UpdateCheeseUI();

        /* if (cheeseCollected >= 5)
         {
             pointsleft = 19;
         }*/

        /*if (cheeseCollected >= 5 && window != null)
        {
            Destroy(window);
            pointsleft = 19;
        }*/
        /* if (cheeseCollected >= 5)
         {
             if (window != null)
             {
                 Destroy(window);
                 pointsleft = 19;
             }
         }

         if (cheeseCollected >= 19  && sewer != null)
         {
             Destroy(sewer);
         }
         if (cheeseCollected == 19)
         {
             pointsleft = 43;
         }

         if (cheeseCollected >= 43 && pipe != null)
         {
             Destroy(pipe);
         }*/
        if (cheeseCollected >= 43)
        {
            if (pipe != null) Destroy(pipe);
         
        }
        else if (cheeseCollected >= 19)
        {
            if (sewer != null) Destroy(sewer);
            pointsleft = 43;
        }
        else if (cheeseCollected >= 5)
        {
            if (window != null) Destroy(window);
            pointsleft = 19;
        }
    }

    void UpdateCheeseUI()
    {
        cheeseText.text = "Score: " + cheeseCollected + " / " + pointsleft;
    }

    public bool HasEnoughCheese()
    {
        return cheeseCollected >= cheeseNeededToWin;
    }



    public void WinGame()
    {
        gameOver = true;
        winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        gameOver = true;
        losePanel.SetActive(true);
        

    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
