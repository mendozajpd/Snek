using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    private ScoreScript score;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreGameObject").GetComponent<ScoreScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.CurrentScore += 1;
        Destroy(gameObject);
    }
}
