using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] private AudioSource _chompSound;
    [SerializeField] private List<GameObject> _snakeSegments;
    [SerializeField] private GameObject _snakeSegmentPrefab;
    [SerializeField] private GameObject _snakeSegmentPrefab2;

    // Segment Changer
    private int _segmentColor = -1;

    private string _loseGame = "Ouchie";

    public List<GameObject> SnakeSegments { get => _snakeSegments;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            _chompSound.Play();
            _segmentHandler();
            Debug.Log("NOMNOM");
        }

        if (collision.gameObject.tag == "Border")
        {
            Debug.Log(_loseGame);
        }

        if(collision.gameObject.tag == "Segment")
        {
            Debug.Log(_loseGame);

        }
    }

    private void _segmentHandler()
    {
        if (_segmentColor == -1)
        {
            GameObject newSegment = Instantiate(_snakeSegmentPrefab, gameObject.transform.parent.transform);
            newSegment.name = "Snake Segment" + _snakeSegments.Count;
            SnakeSegments.Add(newSegment);
            _segmentColor *= -1;
            return;
        }

        if (_segmentColor == 1)
        {
            GameObject newSegment = Instantiate(_snakeSegmentPrefab2, gameObject.transform.parent.transform);
            newSegment.name = "Snake Segment" + _snakeSegments.Count;
            SnakeSegments.Add(newSegment);
            _segmentColor *= -1;
            return;
        }
    }
}
