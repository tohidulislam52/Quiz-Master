using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Questions", fileName ="Question" )]
public class Question : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string QuestionV ="Enter your name ";
    [SerializeField] string[] Answers = new string[4];
    [SerializeField] int carectAnswer;

    public string getQuestion()
    {
        return QuestionV;
    }
    public string GetAnswers(int index) 
    {
        return Answers[index];
    }
    public int GetCarectAnswer()
    {
        return carectAnswer;
    }
    





}
