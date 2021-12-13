using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreElement
{
    private int _score;
    private bool _isNewScore;

    public int Score
    {
        get
        {
            return _score;
        }
    }

    public bool IsNewScore
    {
        get
        {
            return _isNewScore;
        }
    }

    public ScoreElement(int score, bool isNewScore)
    {
        _score = score;
        _isNewScore = isNewScore;
    }
}
