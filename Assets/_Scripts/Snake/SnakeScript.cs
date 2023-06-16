using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _snakeSegments;
    [SerializeField] private GameObject _snakeSegmentPrefab;
    [SerializeField] private GameObject _snakeSegmentPrefab2;

    // Segment Changer
    private int segmentColor = -1;

    private string LoseGame = "Ouchie";

    public List<GameObject> SnakeSegments { get => _snakeSegments;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            SegmentHandler();
            Debug.Log("NOMNOM");
        }

        if (collision.gameObject.tag == "Border")
        {
            Debug.Log(LoseGame);
        }

        if(collision.gameObject.tag == "Segment")
        {
            Debug.Log(LoseGame);

        }
    }

    private void SegmentHandler()
    {
        if (segmentColor == -1)
        {
            GameObject newSegment = Instantiate(_snakeSegmentPrefab, gameObject.transform.parent.transform);
            newSegment.name = "Snake Segment" + _snakeSegments.Count;
            SnakeSegments.Add(newSegment);
            segmentColor *= -1;
            return;
        }

        if (segmentColor == 1)
        {
            GameObject newSegment = Instantiate(_snakeSegmentPrefab2, gameObject.transform.parent.transform);
            newSegment.name = "Snake Segment" + _snakeSegments.Count;
            SnakeSegments.Add(newSegment);
            segmentColor *= -1;
            return;
        }
    }
}
