using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Question", menuName ="Creat Quiz Question", order = 21)]
public class QuestionsSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter your question here..";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion() { return question; }
    public int GetCorrectAnswerIndex() {  return correctAnswerIndex; }

    public string GetAnswer(int index) { return answers[index]; }
}
