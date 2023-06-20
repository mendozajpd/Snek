using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{
    private TextMeshProUGUI settingsButtonPopUpText;


    private void Awake()
    {
        settingsButtonPopUpText = GameObject.FindGameObjectWithTag("SettingsButton").GetComponent<TextMeshProUGUI>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SnakeScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        if (settingsButtonPopUpText != null)
        {
           settingsButtonPopUpText.enabled = true;
        } else
        {
            Debug.Log("Not found homie");
        }
    }
}
