using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject creditspanel;
    public GameObject Pausepenel;
    public GameObject helppanel;
    public GameObject lore;
    public GameObject AHHH;

    public void PlayGame()
    {
        SceneManager.LoadScene("Cat Impawssible");
    }

    public void Back()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }

    public void OpenAHHH()
    {
        AHHH.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseAHHH()
    {
        AHHH.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpenLore()
    {
        lore.SetActive(true);
    }

    public void CloseLore()
    {
        lore.SetActive(false);
    }

    public void OpenHelp()
    {
        helppanel.SetActive(true);
    }

    public void CloseHelp()
    {
        helppanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pausepenel.SetActive(true);
            Time.timeScale = 0f;

        }
    }

    public void BackToGame()
    {
        Pausepenel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenCredits()
    {
        creditspanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditspanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

