using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFruitAnimationScript : MonoBehaviour
{
    private BoxCollider2D boxcoll2d;

    // Snake variable
    [SerializeField] private EatFruitAnimationScript _leadSegment;
    public float _leadSegmentEatSize;
    public int Count;
    public bool TransferEatBulge;
    private bool _eatSize;

    // Pulse Settings
    [SerializeField] PulseSettingsSO pulseSettings;

    // Pulse Variables
    [SerializeField] private float _pulseTime;
    private SnakeScript _snake;
    private float _pulseSize;
    private float _pulseFrequency;
    private float _originalObjectSize;
    private float _colliderSize;

    public bool EatSize { get => _eatSize; }

    private void Awake()
    {
        if (gameObject.tag == "Head")
        {
            boxcoll2d = GetComponent<BoxCollider2D>();
            Count = 1;
        }

        if (gameObject.tag == "Segment")
        {
            boxcoll2d = GetComponent<BoxCollider2D>();
            _leadSegment = GetComponent<SnakeLocationHandler>().LeadGameObject.GetComponent<EatFruitAnimationScript>();
        }

        _snake = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeScript>();

        _pulseSize = pulseSettings.PulseSize;
        _pulseFrequency = pulseSettings.PulseFrequency;
        _originalObjectSize = pulseSettings.OriginalObjectSize;
        _colliderSize = pulseSettings.ColliderSize;
        
    }
    void Start()
    {

    }

    void Update()
    {
        if (gameObject.tag == "Segment" && Count != _leadSegment.Count + 1)
        {
            Count = _leadSegment.Count + 1;
        }

        _pulseAnimationHandler();
    }

    private void _pulseAnimationHandler()
    {
        if (_pulseTime <= _pulseFrequency/Count && _pulseTime > 0)
        {
            TransferEatBulge = true;
        }

       if (_leadSegment != null)
        {
            if (_leadSegment.TransferEatBulge)
            {
                _pulseTime = _pulseFrequency;
            }
        }

        if (_pulseTime <= 0)
        {
            if (_leadSegment != null)
            {
                _leadSegment.TransferEatBulge = false;
                TransferEatBulge = false;
            } else
            {
                TransferEatBulge = false;
            }
        }

        if (_pulseTime > 0)
            {
                _pulseTime -= Time.deltaTime;

                if (boxcoll2d.size != new Vector2(_colliderSize, _colliderSize))
                {
                    boxcoll2d.size = new Vector2(_colliderSize, _colliderSize);
                }

            // This pulses the object
            Vector3 _pulse = new Vector3((_pulseSize * (_pulseTime / _pulseFrequency)) * ((_snake.SnakeSegments.Count - Count + 1) / (float)_snake.SnakeSegments.Count), (_pulseSize * (_pulseTime / _pulseFrequency)) * ((_snake.SnakeSegments.Count - Count + 1) / (float)_snake.SnakeSegments.Count));
            gameObject.transform.localScale = new Vector3(_originalObjectSize, _originalObjectSize) + _pulse;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            _pulseTime = _pulseFrequency;
            Debug.Log("YES");
        }
    }

}
