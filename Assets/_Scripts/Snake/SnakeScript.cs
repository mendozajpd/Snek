using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] private AudioSource _chompSound;
    [SerializeField] private AudioSource _wallHitSound;
    [SerializeField] private AudioSource _hitSelfSound;
    [SerializeField] private GameObject _deathParticles;
    [SerializeField] private List<GameObject> _snakeSegments;
    [SerializeField] private GameObject _snakeSegmentPrefab;
    [SerializeField] private GameObject _snakeSegmentPrefab2;

    // Collider Variables
    BoxCollider2D boxcoll2d;

    // Segment Changer
    private int _segmentColor = -1;


    // Snake State
    private bool _isDead = false;

    // Main Camera Variables
    [SerializeField] private CameraShakeScript _mainCamera;

    // Encapsulated Variables
    public List<GameObject> SnakeSegments { get => _snakeSegments;}
    public bool IsDead { get => _isDead; }

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
            boxcoll2d = GetComponent<BoxCollider2D>();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
            _wallHitSound.Play();
            boxcoll2d.enabled = false;
            _isDead = true;
            Instantiate(_deathParticles, gameObject.transform.position, Quaternion.identity);
            _mainCamera.Shake();
        }

        if(collision.gameObject.tag == "Segment")
        {
            boxcoll2d = GetComponent<BoxCollider2D>();
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
            _hitSelfSound.Play();
            boxcoll2d.enabled = false;
            _isDead = true;
            Instantiate(_deathParticles, gameObject.transform.position, Quaternion.identity);
            _mainCamera.Shake();
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
