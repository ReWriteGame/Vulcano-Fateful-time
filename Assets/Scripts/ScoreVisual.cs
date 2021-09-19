using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreVisual : MonoBehaviour
{
    [SerializeField] private Text output;
    [SerializeField] private ScoreCounter scoreCounter;


    private void OnEnable()
    {
        updateScore();
        scoreCounter.addScoreEvent.AddListener(updateScore);
        scoreCounter.takeAwayScoreEvent.AddListener(updateScore);
    }
    private void OnDisable()
    {
        scoreCounter.addScoreEvent.RemoveListener(updateScore);
        scoreCounter.takeAwayScoreEvent.RemoveListener(updateScore);
    }
    public void updateScore()
    {
        output.text = $"SCORE: {scoreCounter.Score}";
    }
}
