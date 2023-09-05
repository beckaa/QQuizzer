using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="question",menuName="Quizitems",order =1)]
public class QuizItem : ScriptableObject
{
    public int id;
    [TextArea (2,5)]
    public string Question;
    [TextArea(2, 3)]
    public string[] possibleAnswers = new string[4];
    [TextArea(1, 2)]
    public string rightAnswer;
    public string[] getPossibleAnswers()
    {
        return possibleAnswers;
    }
    public string getQuestion()
    {
        return Question;
    }
    public string getRightAnswer()
    {
        return rightAnswer;
    }
}
