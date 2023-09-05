using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    //list of QuizItems
    public QuizItem[] questions;
    // Start is called before the first frame update
    void Start()
    {
        //first click team one red begins
        PlayerPrefs.SetInt("team1", 1);
        PlayerPrefs.SetInt("team2", 0);
        PlayerPrefs.SetInt("EndGame", 0);
        //second mouse click team blue chooses
    }
}
