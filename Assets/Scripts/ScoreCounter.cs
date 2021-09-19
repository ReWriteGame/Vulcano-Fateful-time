using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private float maxScore = 0;
    [SerializeField] private float minScore = 0;

    public UnityEvent addScoreEvent;
    public UnityEvent takeAwayScoreEvent;
    public UnityEvent isMinScoreEvent;
    public UnityEvent isMaxScoreEvent;
    public UnityEvent changeScoreEvent;

    public float Score { get => score; private set => score = value; }

    public void add(float scr)
    {
        if (scr < 0) return;
        score = (score + scr) >= maxScore ? maxScore : (score + scr);

        // Events
        changeScoreEvent?.Invoke();
        addScoreEvent?.Invoke();
        if (score >= maxScore) isMaxScoreEvent?.Invoke();
    }
    public void takeAway(float scr)
    {
        if (scr < 0) return;
        score = (score - scr) <= minScore ? minScore : (score - scr);

        // Events
        changeScoreEvent?.Invoke();
        takeAwayScoreEvent?.Invoke();
        if (score <= minScore) isMinScoreEvent?.Invoke();
    }
}
