using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public main main;
    public void loadQuestions(string levelName)
    {

        main.questions =Resources.LoadAll<QuizItem>("Quizitems/"+levelName);
    }
}
