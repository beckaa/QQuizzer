using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class teamBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redTeam;
    public GameObject blueTeam;
    public GameObject score;
    public GameObject[] team1answers = new GameObject[4];
    public GameObject[] team2answers = new GameObject[4];
    public TMP_Text team1;
    public TMP_Text team2;

    public void clickedOnButton() { 
        if (PlayerPrefs.GetInt("team1") == 1)
        {
            redTeam.SetActive(true);
            if (checkIfAnswered(team2answers))
            {
                PlayerPrefs.SetInt("Teamvotedfirstbefore", 2);
                PlayerPrefs.SetInt("team1", 0);
                PlayerPrefs.SetInt("team2", 0);
                score.SetActive(true);
                score.GetComponent<Score>().updateScore();
            }
            else
            {
                PlayerPrefs.SetInt("team1", 0);
                PlayerPrefs.SetInt("team2", 1);
                team1.color = new Color(1f, 1f, 1f, 90f / 255f);
                team2.color = new Color(0, 89f / 255f, 218f / 255f);
            }

        }
        else if(PlayerPrefs.GetInt("team2")==1)
        {
            blueTeam.SetActive(true);

            if (checkIfAnswered(team1answers))
            {
                PlayerPrefs.SetInt("team1", 0);
                PlayerPrefs.SetInt("team2", 0);
                PlayerPrefs.SetInt("Teamvotedfirstbefore", 1);
                score.SetActive(true);
                score.GetComponent<Score>().updateScore();
            }
            else
            {
                PlayerPrefs.SetInt("team1", 1);
                PlayerPrefs.SetInt("team2", 0);
                team1.color = new Color(255f / 255f, 154f / 255f, 0);
                team2.color = new Color(1f, 1f, 1f, 90f / 255f);
            }
        }
    }
    bool checkIfAnswered(GameObject[] list)
    {
        for(int i =0; i< list.Length; i++)
        {
            if (list[i].gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
}
