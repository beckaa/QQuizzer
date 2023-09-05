using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] team1answers = new GameObject[4];
    public GameObject[] team2answers = new GameObject[4];
    public GameObject[] buttons=new GameObject[4];
    QuizItem currentquizitem;
    public main main;

    public void updateScore()
    {
        int id = PlayerPrefs.GetInt("item");
        currentquizitem = main.questions[id-1];
        string rightanswer = currentquizitem.getRightAnswer().ToString();
        for (int i = 0; i < buttons.Length; i++)
        {

            if (rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text))
            {
                if (team1answers[i].activeSelf)
                {
                    PlayerPrefs.SetInt("team1Points", PlayerPrefs.GetInt("team1Points", 0) + 10);
                }
                if (team2answers[i].activeSelf)
                {
                    PlayerPrefs.SetInt("team2Points", PlayerPrefs.GetInt("team2Points", 0) + 10);
                }
            }
        }
    }
}
