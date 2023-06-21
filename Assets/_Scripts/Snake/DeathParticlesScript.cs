using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticlesScript : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyGameObject", 2f);
    }

    void Update()
    {
        
    }


    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
