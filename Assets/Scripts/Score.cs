using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{


    int _correctAnswer = 0;
    int _numberAnswered = 0;

    public void UpdateCorrectAnsweres()
    {
        _correctAnswer++;
    }
    public int CorrectAnswered()
    {
        return _correctAnswer;
    }
    public void UpdateNumberAnswered()
    {
        _numberAnswered++;
    }

    public int NumberAnswered()
    {
        return _numberAnswered;
    }
    public int CalculateAnswer()
    {
       return Mathf.RoundToInt(_correctAnswer/(float)_numberAnswered * 100);
    }
}
