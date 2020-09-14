using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    private ScoreData _scoreData;

    public int BestScore => _scoreData.BestScore;
    public int CurrentScore => _scoreData.CurrentScore;

    [HideInInspector] public UnityEvent BestScoreChange;
    [HideInInspector] public UnityEvent CurrentScoreChange;

    public void Initialize(ScoreData scoreData)
    {
        _scoreData = scoreData;
    }

    public void AddCurrentScore()
    {
        _scoreData.CurrentScore++;
        CurrentScoreChange.Invoke();
    }

    public void ResetCurrentScore()
    {
        if (CurrentScore > BestScore)
        {
            _scoreData.BestScore = CurrentScore;
            BestScoreChange.Invoke();
        }
        _scoreData.CurrentScore = 0;
        CurrentScoreChange.Invoke();
    }

}
