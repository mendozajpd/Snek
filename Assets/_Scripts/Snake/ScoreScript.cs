using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int CurrentScore = 0;
    private TextMeshProUGUI _scoreText;
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreText.text = CurrentScore.ToString();
    }
}
