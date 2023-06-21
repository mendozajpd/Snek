using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //Pause Variables
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas scoreCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gameStartCanvas;
    private SnakeScript _snake;
    private bool _isPaused = false;

    void Start()
    {
        _snake = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeScript>();
    }

    void Update()
    {
        _gameStartCanvasHider();
        _pauseButtonHandler();
        if (_snake.IsDead)
        {
            Invoke("_gameOverScreenHandler", 1f);
        }
    }

    private void _gameStartCanvasHider()
    {
        if (!_snake.GetComponent<SnakeMovement>().GameStart)
        {
            gameStartCanvas.enabled = false;
        }
    }

    private void _gameOverScreenHandler()
    {

            scoreCanvas.enabled = false;
            gameOverCanvas.enabled = true;
    }

    private void _pauseButtonHandler()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!_isPaused)
            {
                _isPaused = true;
            } else if (_isPaused)
            {
                _isPaused = false;
            }

            _pauseHandler();
        }
    }

    private void _pauseHandler()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;

        }
        else if (!_isPaused)
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }
    }

    public void ContinueButtonPressed()
    {
        pauseCanvas.enabled = false;
        _isPaused = false;
        Time.timeScale = 1;
    }

    public void ExitToMainMenuPressed()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitToDesktopPressed()
    {
        Application.Quit();
    }

    public void ReloadButtonPressed()
    {
        SceneManager.LoadScene("SnakeScene");
    }
}
