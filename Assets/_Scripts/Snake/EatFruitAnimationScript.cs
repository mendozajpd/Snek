using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFruitAnimationScript : MonoBehaviour
{
    private BoxCollider2D boxcoll2d;

    // Fruit Finding Variables
    private FruitScript _fruit;

    // Snake variable
    [SerializeField] private EatFruitAnimationScript _leadSegment;
    public float LeadSegmentEatSize;
    public int Count;
    public bool TransferEatBulge;
    private SnakeMovement _snakeMovement;
    private bool _eatSize;

    // Pulse Settings
    [SerializeField] private PulseSettingsSO _pulseSettings;

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
        _setHeadAndSegment();
        _findSnakeComponents();
        _setPulseSettings();
    }



    void Start()
    {

    }

    void Update()
    {
        if(_leadSegment == null && gameObject.tag != "Head")
        {
            _setHeadAndSegment();
        } else
        {
            _findSetFruit();
            _widenMouthAnimation();
            _segmentCounter();
            _pulseAnimationHandler();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            _pulseTime = _pulseFrequency;
        }
    }

    private void _widenMouthAnimation()
    {
        if (gameObject.tag == "Head" && _fruit != null)
        {
            float distance = Vector3.Distance(gameObject.transform.position, _fruit.transform.position);
            float minDistance = 0;
            float maxDistance = 8;
            float minScale = 1;
            float maxScale = 1.5f;

            float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            float scaleValue = Mathf.Lerp(maxScale, minScale, normalizedDistance);

            if (distance < maxDistance)
            {
                if (!_snakeMovement.LastDirectionHorizontal)
                {
                    gameObject.transform.localScale = new Vector2(scaleValue, 1);
                }

                if (_snakeMovement.LastDirectionHorizontal)
                {
                    gameObject.transform.localScale = new Vector2(1, scaleValue);
                }
            }
            else
            {
                gameObject.transform.localScale = new Vector2(1, 1);
            }

        }
    }

    private void _findSetFruit()
    {
        if (_fruit == null)
        {
            try
            {
                _fruit = GameObject.FindGameObjectWithTag("Food").GetComponent<FruitScript>();
            }
            catch
            {
                Debug.Log("No fruit found.");
            }
        }
    }

    private void _findSnakeComponents()
    {
        _snake = GameObject.FindGameObjectWithTag("Head").GetComponent<SnakeScript>();
        _snakeMovement = GetComponent<SnakeMovement>();
    }

    private void _segmentCounter()
    {
        if (gameObject.tag == "Segment" && Count != _leadSegment.Count + 1)
        {
            Count = _leadSegment.Count + 1;
        }
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

    private void _setHeadAndSegment()
    {
        if (gameObject.tag == "Head")
            {
                boxcoll2d = GetComponent<BoxCollider2D>();
                Count = 1;
            }

          
        if (gameObject.tag == "Segment")
        {
            boxcoll2d = GetComponent<BoxCollider2D>();
            try
            {
                _leadSegment = GetComponent<SnakeLocationHandler>().LeadGameObject.GetComponent<EatFruitAnimationScript>();
            } catch
            {
                return;
            }
        }

    }

    private void _setPulseSettings()
    {
        _pulseSize = _pulseSettings.PulseSize;
        _pulseFrequency = _pulseSettings.PulseFrequency;
        _originalObjectSize = _pulseSettings.OriginalObjectSize;
        _colliderSize = _pulseSettings.ColliderSize;
    }



}
