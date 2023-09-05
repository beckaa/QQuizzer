using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class loadItem : MonoBehaviour
{

    public TMP_Text question;
    public TMP_Text[] possibleAnswers = new TMP_Text[4];
    public main main;
    QuizItem item;
    private int id;
    public Button[] answerButtonList;
    public GameObject score;
    public TMP_Text team1;
    public TMP_Text team2;
    public Animator character_animator;
    //load first item after game start
    public void loadQuizItem()
    {
        id = PlayerPrefs.GetInt("item", 0);
        //team1 starts
        int votedfirst = PlayerPrefs.GetInt("Teamvotedfirstbefore");
        if (votedfirst == 1)
        {
            PlayerPrefs.SetInt("team2", 1);
            PlayerPrefs.SetInt("team1", 0);
            PlayerPrefs.SetInt("Teamvotedfirstbefore", 2);
            team1.color = new Color(1f, 1f, 1f, 90f / 255f);
            team2.color = new Color(0, 89f / 255f, 218f / 255f);
        }
        else
        {
            PlayerPrefs.SetInt("Teamvotedfirstbefore", 1);
            PlayerPrefs.SetInt("team1", 1);
            PlayerPrefs.SetInt("team2", 0);
            team1.color = new Color(255f / 255f, 154f / 255f, 0);
            team2.color = new Color(1f, 1f, 1f, 90f / 255f);
        }

        score.SetActive(false);
        GameObject[] playermarks = GameObject.FindGameObjectsWithTag("playermarks");

        //reset teammarks
        for (int i = 0; i < playermarks.Length; i++)
        {
            playermarks[i].SetActive(false);
        }
        if (id < main.questions.Length)
        {
            item = main.questions[id];
            question.text = item.getQuestion();
            for (int i = 0; i < possibleAnswers.Length; i++)
            {
                possibleAnswers[i].text = item.getPossibleAnswers()[i];
            }
            id++;
            PlayerPrefs.SetInt("item", id);
        }
        else
        {
            PlayerPrefs.SetInt("EndGame", 1);
            PlayerPrefs.SetInt("team1", 2);
            PlayerPrefs.SetInt("team2", 2);
        }
    }
    public void resetAngryBool()
    {
        character_animator.SetBool("angry 0", false);
    }
}
