using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentScript : MonoBehaviour
{
    // This Segments Location Handler
    private SnakeLocationHandler _snakeLocation;

    // Lead Segment Location Handler
    public SnakeLocationHandler _leadSnakeLocation;

    private SnakeMovement _moveTime;

    private void Awake()
    {
        _snakeLocation = GetComponent<SnakeLocationHandler>();
        if (gameObject.tag != "Head")
        {
            _leadSnakeLocation = _snakeLocation.LeadGameObject.GetComponent<SnakeLocationHandler>();
        }
        _moveTime = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeMovement>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (gameObject.tag != "Head")
        {
            if(_moveTime.MoveTime <= 0)
            {
                _followParentSegment();
            }

            //if (gameObject.transform.position == _snakeLocation.LastLocation)
            //{
            //}
        }
    }

    private void _followParentSegment()
    {
        // Sets current location to last location before changing location
        _snakeLocation.LastLocation = gameObject.transform.position;
        // Makes last parent location to current location
        gameObject.transform.position = _leadSnakeLocation.LastLocation;

    }
}
