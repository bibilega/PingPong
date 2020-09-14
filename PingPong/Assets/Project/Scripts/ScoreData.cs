using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreData
{
    public int BestScore;
    public int CurrentScore;

    public ScoreData(int bestScore)
    {
        BestScore = bestScore;
        CurrentScore = 0;
    }
}
