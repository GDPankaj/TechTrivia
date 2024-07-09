using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    private void Awake()
    {
        quiz = FindAnyObjectByType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }

    private void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(quiz.GetIsGameComplete())
        {
            endScreen.gameObject.SetActive(true);
            quiz.gameObject.SetActive(false);
            endScreen.ShowFinalScore();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
