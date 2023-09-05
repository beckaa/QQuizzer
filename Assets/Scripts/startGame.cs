using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("item", 0);
        PlayerPrefs.SetInt("team1Points", 0);
        PlayerPrefs.SetInt("team2Points", 0);
        PlayerPrefs.SetInt("team1", 1);
        PlayerPrefs.SetInt("team2", 0);
        PlayerPrefs.SetInt("Teamvotedfirstbefore", 2);
    }
}
