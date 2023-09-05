using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetScore : MonoBehaviour
{
    public Button[] buttons = new Button[4];
    public GameObject[] playermarks;
    public Animator character_animator;
    public void resetGame()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.GetComponent<Button>().interactable = true;
        }
        //reset teammarks
        for (int i = 0; i < playermarks.Length; i++)
        {
            playermarks[i].SetActive(false);
        }
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("item", 0);
        PlayerPrefs.SetInt("team1Points", 0);
        PlayerPrefs.SetInt("team2Points", 0);
        PlayerPrefs.SetInt("team1", 1);
        PlayerPrefs.SetInt("team2", 0);
        PlayerPrefs.SetInt("Teamvotedfirstbefore", 2);
        character_animator.SetBool("angry 0", false);
    }
}
