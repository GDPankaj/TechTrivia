using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer;
    [SerializeField] float showAnswerTimer;
    float fillFraction;

    [SerializeField]float timerValue;

    bool isAnswering = true;
    bool loadNextQuestion =true;

    private void Awake()
    {
        timerValue = timeToAnswer;
        fillFraction = timerValue/timerValue;
    }
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnswering)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue/timeToAnswer;
            }
            else
            {
                timerValue = showAnswerTimer;
                isAnswering = false;
            }
        }
        else 
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue/showAnswerTimer;
            }
            else
            {
                timerValue = timeToAnswer;
                isAnswering = true;
                loadNextQuestion = true;
            }
        }

    }
    public void CancelTimer ()
    {
        timerValue = 0;
    }

    public bool GetBoolLoadQuestion()
    {
        return loadNextQuestion;
    }
    public void SetBoolLoadQuestion(bool value)
    {
        loadNextQuestion = value;
    }
    public float GetFillFraction() 
    {
        return fillFraction;
    }

    public bool IsAnswering()
    {
        return isAnswering;
    }
}
