using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{

    [SerializeField] private float _shakeMagnitude;
    [SerializeField] private float _shakeDuration;
    private Vector3 originalPosition;
    private float currentShakeDuration;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (currentShakeDuration > 0 )
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * _shakeMagnitude * currentShakeDuration;
            currentShakeDuration -= Time.deltaTime;
        } else
        {
            currentShakeDuration = 0;
            if (transform.localPosition != originalPosition)
            {
                transform.localPosition = originalPosition;
            }
        }
    }

    public void Shake()
    {
        currentShakeDuration = _shakeDuration;
    }

}
