using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitParticlesScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Invoke("_destroyGameObject", 0.8f);
    }


    private void _destroyGameObject()
    {
        Destroy(gameObject);
    }
}
