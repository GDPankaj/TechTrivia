using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI _endText;
    Score _finalScore;

    private void Awake()
    {
        _finalScore = FindAnyObjectByType<Score>();
    }
    public void ShowFinalScore()
    {
        _endText.text = $"Congratulation! Your Score {_finalScore.CalculateAnswer()}%";
    }
}
