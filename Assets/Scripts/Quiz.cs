using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<QuestionsSO> _questions = new List<QuestionsSO>();
    QuestionsSO currentQuestion;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons = new GameObject[4];
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] Slider _progressSlider;

    [SerializeField] Image timerImage;
    [SerializeField] AudioClip correctAnswerSfx;
    [SerializeField] AudioClip wrongAnswerSfx;

    AudioManager audioManger;
    Timer _timer;
    Score _scoreRecorded;
    
    int correctAnswerIndex;
    bool hasAnswered = false;
    bool isGameComplete;
    bool timerRanOut = false;
    

    void Awake()
    {
        _timer = FindAnyObjectByType<Timer>();
        _scoreRecorded = FindAnyObjectByType<Score>();
        audioManger = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        _progressSlider.maxValue = _questions.Count;
        _progressSlider.value = 0;
    }
    void Update()
    {
        timerImage.fillAmount = _timer.GetFillFraction();
        if (_timer.GetBoolLoadQuestion())
        {
            if(_progressSlider.value == _progressSlider.maxValue)
            {
                isGameComplete = true;
                return;
            }

            GetNextQuestion();
            hasAnswered = false;
        }
        else if (!hasAnswered && !_timer.IsAnswering())
        {
            DisplayAnswer(-1);
            SetButtonState(false);
            hasAnswered= true;
        }
    }
    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonsSprite(defaultButtonSprite);
        GetRandomQuestion();
        _timer.SetBoolLoadQuestion(false);
        _scoreRecorded.UpdateNumberAnswered();
        _progressSlider.value++;
        DisplayQuestion();
    }

    void GetRandomQuestion()
    {
        if(_questions.Count != 0)
        {
            int _index = Random.Range(0, _questions.Count);
            currentQuestion = _questions[_index];
            if(_questions.Contains(currentQuestion))
                {
                    _questions.Remove(currentQuestion);
                }
        }
       
    }
    void DisplayQuestion()
    {
        if(currentQuestion != null)
        {
            questionText.text = currentQuestion.GetQuestion();
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();

            for (int i = 0; i < answerButtons.Length; i++)
                {
                    TextMeshProUGUI answerText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                    answerText.text = currentQuestion.GetAnswer(i);
                }
        }
        
    }

    public void OnAnswerSelected(int index) 
    {
        DisplayAnswer(index);
        SetButtonState(false);
        _timer.CancelTimer();
        _scoreText.text = $"Score: {_scoreRecorded.CalculateAnswer()}%";
        hasAnswered = true;
    }
    void SetButtonState(bool _state)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponent<Button>().interactable = _state;
            }
        }

    void SetDefaultButtonsSprite(Sprite _sprite)
    {
        for(int i = 0;i < answerButtons.Length;i++)
        {
            Image spriteImage = answerButtons[i].GetComponent<Image>();
            spriteImage.sprite = _sprite;
        }
    }

    void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            Image correctAnswerImage = answerButtons[index].GetComponent<Image>();
            correctAnswerImage.sprite = correctAnswerSprite;
            _scoreRecorded.UpdateCorrectAnsweres();
            audioManger.PlaySFX(correctAnswerSfx); Debug.Log("hello");
        }

        else
        {
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Wrong! Correct answer is - " + correctAnswer;
            Image correctAnswerImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            correctAnswerImage.sprite = correctAnswerSprite;
            audioManger.PlaySFX(wrongAnswerSfx);Debug.Log("hello");
        }
    }

    public bool GetIsGameComplete()
    {
        return isGameComplete;
    }
}
