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
        if (collision.gameObject.tag == "Head")
        {
            _fruitEaten();
        }


    }

    private void _fruitEaten()
    {
        score.CurrentScore += 1;
        Destroy(gameObject);
    }
}
