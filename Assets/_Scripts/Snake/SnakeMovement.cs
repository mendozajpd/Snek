using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    // Snake Variables
    private SnakeScript _snake;

    // Game State Variables
    bool gameStart = true;

    // Difficulty
    public int gameDifficulty;

    // Movetime
    private float _moveTime = 0;

    // Direction Handling Variables
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _moveDistance = 0;
    private float _moveSpeed = 0; // Determines how fast the snake will move
    private SnakeLocationHandler snakeLocation;
    private bool goingUp;
    private bool goingDown;
    private bool goingRight;
    private bool goingLeft;
    private bool justMoved;

    // Audio Handling Variables
    [SerializeField] private AudioSource _move1;
    [SerializeField] private AudioSource _move2;
    private int _audioCount = 1;



    // Direction Variables
    private bool lastDirectionHorizontal = true;

    public bool LastDirectionHorizontal { get => lastDirectionHorizontal; }
    public bool GameStart { get => gameStart; }

    void Start()
    {
        snakeLocation = GetComponent<SnakeLocationHandler>();

        _setGameDifficulty();

        _moveTime = _moveSpeed;
    }



    void Update()
    {
        _getSnakeScript();

        if (_snake != null && !_snake.IsDead)
        {
            _userControlHandler();
            _moveTimerHandler();
            _audioHandler();
        }
    }



    private void _userControlHandler()
    {
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && lastDirectionHorizontal)
        {
            goingUp = true;
            goingDown = false;
            goingLeft = false;
            goingRight = false;

            if (gameStart)
            {
                gameStart = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && lastDirectionHorizontal)
        {
            goingUp = false;
            goingDown = true;
            goingLeft = false;
            goingRight = false;
            
            if (gameStart)
            {
                gameStart = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !lastDirectionHorizontal || (gameStart && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))))
        {
            goingUp = false;
            goingDown = false;
            goingLeft = true;
            goingRight = false;

            if (gameStart)
            {
                gameStart = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !lastDirectionHorizontal)
        {
            goingUp = false;
            goingDown = false;
            goingLeft = false;
            goingRight = true;
        }

    }

    private void _moveTimerHandler ()
    {
        if (_moveTime <= 0)
        {
            snakeLocation.LastLocation = transform.position;

            if (goingUp)
            {
                Vector3 newPosition = _rb.transform.position + new Vector3(0f, _moveDistance,0f);
                _rb.transform.position = newPosition;
                if(lastDirectionHorizontal)
                {
                    lastDirectionHorizontal = false;
                    justMoved = true;
                }
                
            }

            if (goingDown)
            {
                Vector3 newPosition = _rb.transform.position - new Vector3(0f, _moveDistance);
                _rb.transform.position = newPosition;
                if (lastDirectionHorizontal)
                {
                    lastDirectionHorizontal = false;
                    justMoved = true;
                }
            }

            if (goingLeft)
            {
                Vector3 newPosition = _rb.transform.position - new Vector3(_moveDistance, 0f);
                _rb.transform.position = newPosition;
                if (!lastDirectionHorizontal)
                {
                    lastDirectionHorizontal = true;
                    justMoved = true;
                }
            }
          
            if (goingRight)
            {
                Vector3 newPosition = _rb.transform.position + new Vector3(_moveDistance, 0f);
                _rb.transform.position = newPosition;
                if (!lastDirectionHorizontal)
                {
                    lastDirectionHorizontal = true;
                    justMoved = true;
                }
            }

            _moveTime = _moveSpeed;
        }

        if (_moveTime > 0)
        {
            _moveTime -= Time.deltaTime;
        }
    }

    private void _setGameDifficulty()
    {
        switch (gameDifficulty)
        {
            case 1:
                _moveSpeed = 0.3f;
                break;
            case 2:
                _moveSpeed = 0.2f;
                break;
            case 3:
                _moveSpeed = 0.1f;
                break;
            case 4:
                _moveSpeed = 0.05f;
                break;
            default:
                gameDifficulty = 3;
                break;
        }
    }

    private void _audioHandler()
    {
        if (justMoved)
        {
            if (_audioCount == 1)
            {
                _move1.Play();
                _audioCount *= -1;
                justMoved = false;
                return;
            }

            if (_audioCount == -1)
            {
                _move2.Play();
                _audioCount *= -1;
                justMoved = false;
                return;
            }
        }
    }

    private void _getSnakeScript()
    {
        if (_snake == null)
        {
            try
            {
                _snake = GetComponent<SnakeScript>();
            }
            catch
            {
            }
        }
    }

}
