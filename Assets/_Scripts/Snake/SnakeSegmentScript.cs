using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentScript : MonoBehaviour
{
    // This Segments Location Handler
    private SnakeLocationHandler _snakeLocation;

    // Lead Segment Location Handler
    public SnakeLocationHandler _leadSnakeLocation;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _snakeLocation = GetComponent<SnakeLocationHandler>();
        if (gameObject.tag != "Head")
        {
            _getLeadSnake();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }



    void Start()
    {

    }

    void Update()
    {
        if (_leadSnakeLocation == null)
        {
            _getLeadSnake();
        }

        if (gameObject.tag != "Head" && _leadSnakeLocation != null)
        {
                _followParentSegment();
        }
    }

    private void _followParentSegment()
    {
        // Sets current location to last location before changing location
        _snakeLocation.LastLocation = gameObject.transform.position;
        // Makes last parent location to current location
        if (_leadSnakeLocation.gameObject.transform.position != _leadSnakeLocation.LastLocation)
        {
            gameObject.transform.position = _leadSnakeLocation.LastLocation;
            
            if (!_spriteRenderer.enabled)
            {
                _spriteRenderer.enabled = true;
            }
        }


    }

    private void _getLeadSnake()
    {
        try
        {
            _leadSnakeLocation = _snakeLocation.LeadGameObject.GetComponent<SnakeLocationHandler>();
        } catch
        {
            return;
        }
    }

}
