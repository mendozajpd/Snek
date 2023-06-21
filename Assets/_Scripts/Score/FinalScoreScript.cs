using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreScript : MonoBehaviour
{
    private ScoreScript _score;
    private TextMeshProUGUI _finalScoreText;

    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("ScoreGameObject").GetComponent<ScoreScript>();
        _finalScoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _finalScoreText.text = _score.CurrentScore.ToString();
    }
}
