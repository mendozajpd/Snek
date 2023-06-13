using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _snakeSegments;
    [SerializeField] private GameObject _snakeSegmentPrefab;

    public List<GameObject> SnakeSegments { get => _snakeSegments;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            GameObject newSegment = Instantiate(_snakeSegmentPrefab, gameObject.transform.parent.transform);
            newSegment.name = "Snake Segment" + _snakeSegments.Count;
            SnakeSegments.Add(newSegment);
            Debug.Log("NOMNOM");
        }

        if(collision.gameObject.tag == "Border")
        {
            Debug.Log("Ouchie");
        }
    }
}
