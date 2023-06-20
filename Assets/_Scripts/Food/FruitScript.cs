using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    // Pulse Settings
    [SerializeField] PulseSettingsSO pulseSettings;

    // Death Particles
    [SerializeField] GameObject deathParticles;

    // Pulse Variables
    private float _pulseTime;
    private float _pulseSize;
    private float _pulseFrequency;
    private float _originalObjectSize;

    // Score Variables
    private ScoreScript _score;
    
    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("ScoreGameObject").GetComponent<ScoreScript>();
        _pulseSize = pulseSettings.PulseSize;
        _pulseFrequency = pulseSettings.PulseFrequency;
        _originalObjectSize = pulseSettings.OriginalObjectSize;
    }

    void Update()
    {
        _pulseAnimationHandler();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            _fruitEaten();
        }


    }

    private void _fruitEaten()
    {
        _score.CurrentScore += 1;
        Instantiate(deathParticles,gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void _pulseAnimationHandler()
    {
        if (_pulseTime <= 0)
        {
            _pulseTime = _pulseFrequency;
        }

        if (_pulseTime > 0)
        {
            _pulseTime -= Time.deltaTime;
            
            // This pulses the object
            Vector3 _pulse = new Vector3(_pulseSize * (_pulseTime/_pulseFrequency), _pulseSize * (_pulseTime/_pulseFrequency));
            gameObject.transform.localScale = new Vector3(_originalObjectSize,_originalObjectSize) + _pulse;
        }



    }
}
