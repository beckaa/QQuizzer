using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class loadScore : MonoBehaviour
{
    public TMP_Text team1T;
    public TMP_Text team2T;
    public Image img;
    public Image img2;
    public GameObject trophy_T1;
    public GameObject trophy_T2;
    public main mainObject;
    // Start is called before the first frame update
    public void loadPlayerScore()
    {
        float countquestions = mainObject.questions.Length * 10;
        float team1 = PlayerPrefs.GetInt("team1Points", 0);
        float team2 = PlayerPrefs.GetInt("team2Points", 0);
        team1T.text = "Points: " + team1;
        team2T.text = "Points: " + team2;
        img.rectTransform.sizeDelta = new Vector2(150f, (team1 / countquestions) * 330f);
        img2.rectTransform.sizeDelta = new Vector2(150f, (team2 / countquestions) * 330f);
        Vector2 position1 = img.transform.position;
        position1.y = position1.y + ((team1 / countquestions) * 330f) / 2f;
        img.transform.position = position1;
        Vector2 position2 = img2.transform.position;
        position2.y = position2.y + ((team2 / countquestions) * 330f) / 2f;
        img2.transform.position = position2;
        if (team1 > team2 && team2 < team1)
        {
            trophy_T1.SetActive(true);
        }
        else if (team2 > team1 && team1 < team2)
        {
            trophy_T2.SetActive(true);
        }
        else if(team1 ==0 && team2 == 0)
        {
            trophy_T1.SetActive(false);
            trophy_T2.SetActive(false);
        }
        else
        {
            trophy_T1.SetActive(true);
            trophy_T2.SetActive(true);
        }
    }
        public void resetStatPosition()
    {
        img.rectTransform.sizeDelta = new Vector2(150f, 100);
        img2.rectTransform.sizeDelta = new Vector2(150f, 100);
        Vector2 pos1 = img.transform.position;
        Vector2 pos2 = img2.transform.position;
        pos1.y = 330;
        pos2.y = 330;
        img.transform.position = pos1;
        img2.transform.position = pos2;
    }
}


