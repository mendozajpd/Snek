using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed = 0; // Determines how fast the snake will move
    [SerializeField] private int _moveDistance = 0;
    private float _moveTime = 0;
    private bool goingUp;
    private bool goingDown;
    private bool goingRight;
    private bool goingLeft;

    // Direction Variables
    private bool lastDirectionHorizontal;
    
    void Start()
    {
        _moveTime = _moveSpeed;
        
    }

    void Update()
    {
        // user controls
        userControlHandler();
        _moveTimerHandler();
    }

    private void FixedUpdate()
    {
        // move the snake
    }

    private void userControlHandler()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && lastDirectionHorizontal)
        {
            goingUp = true;
            goingDown = false;
            goingLeft = false;
            goingRight = false;
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && lastDirectionHorizontal)
        {
            goingUp = false;
            goingDown = true;
            goingLeft = false;
            goingRight = false;
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !lastDirectionHorizontal)
        {
            goingUp = false;
            goingDown = false;
            goingLeft = true;
            goingRight = false;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !lastDirectionHorizontal)
        {
            goingUp = false;
            goingDown = false;
            goingLeft = false;
            goingRight = true;
            
        }

    }



    // make timer for movement
    // make snake move 1 depending on how fast the difficulty is

    private void _moveTimerHandler ()
    {
        if (_moveTime <= 0)
        {
            if (goingUp)
            {
                Vector3 newPosition = _rb.transform.position + new Vector3(0f, _moveDistance,0f);
                _rb.transform.position = newPosition;
                lastDirectionHorizontal = false;
            }

            if (goingDown)
            {
                Vector3 newPosition = _rb.transform.position - new Vector3(0f, _moveDistance);
                _rb.transform.position = newPosition;
                lastDirectionHorizontal = false;
            }

            if (goingLeft)
            {
                Vector3 newPosition = _rb.transform.position - new Vector3(_moveDistance, 0f);
                _rb.transform.position = newPosition;
                lastDirectionHorizontal = true;
            }
          
            if (goingRight)
            {
                Vector3 newPosition = _rb.transform.position + new Vector3(_moveDistance, 0f);
                _rb.transform.position = newPosition;
                lastDirectionHorizontal = true;
            }

            _moveTime = _moveSpeed;
        }

        if (_moveTime > 0)
        {
            _moveTime -= Time.deltaTime;
        }
    }

    

}
