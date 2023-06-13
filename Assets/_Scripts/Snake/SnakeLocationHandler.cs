using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLocationHandler : MonoBehaviour
{
    public Vector3 LastLocation;
    public GameObject LeadGameObject;
    private SnakeScript _snakeHead;

    private void Awake()
    {
        if (gameObject.tag != "Head")
        {
            SetLeadSegment();
        }
    }


    private void Update()
    {
        
    }

    private void SetLeadSegment()
    {
        _snakeHead = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeScript>();
        if (_snakeHead.SnakeSegments.Count == 0)
        {
            LeadGameObject = _snakeHead.gameObject;
        }
        else
        {
            LeadGameObject = _snakeHead.SnakeSegments[_snakeHead.SnakeSegments.Count - 1];
        }

    }

}
