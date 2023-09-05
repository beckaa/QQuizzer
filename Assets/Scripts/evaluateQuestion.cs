using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class evaluateQuestion : MonoBehaviour
{
    public Button[] buttons = new Button[4];
    QuizItem script;
    QuizItem currentQuizitem;
    string rightanswer;
    public Button NextQuestion;
    public GameObject End;
    public main main;
    public GameObject[] team1answers;
    public GameObject[] team2answers;
    public AudioSource source;
    public AudioClip winningSound;
    public AudioClip loosingSound;
    public AudioClip clip;
    public Animator character_animator;
    int id;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("team1") == 1 && PlayerPrefs.GetInt("team2") == 0 || PlayerPrefs.GetInt("team1") == 0 && PlayerPrefs.GetInt("team2") == 1)
        {
            
            StopCoroutine("wait");
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.GetComponent<Button>().interactable = true;
            }
        }
        if (PlayerPrefs.GetInt("team1") == 0 && PlayerPrefs.GetInt("team2") == 0)
        {
            id = PlayerPrefs.GetInt("item");
            getCurrentQuizItem();
            rightanswer = script.getRightAnswer();
            StartCoroutine("wait");
        }
    }

    public void getCurrentQuizItem()
    {
            currentQuizitem = main.questions[id-1];
            script = currentQuizitem;
    }
     IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < buttons.Length; i++)
        {
            if(team1answers[i].activeSelf==true && team2answers[i].activeSelf == true&& rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text)&& buttons[0].interactable == true)
            {
                source.PlayOneShot(winningSound);
            }else if(team1answers[i].activeSelf == false && team2answers[i].activeSelf == false && rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text)&& buttons[0].interactable == true)
            {
                source.PlayOneShot(loosingSound);
                character_animator.SetBool("angry 0",true);
            }
            else if(team1answers[i].activeSelf == false && rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text) && buttons[0].interactable == true
                || team2answers[i].activeSelf == false && rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text) && buttons[0].interactable == true)
            {
                source.PlayOneShot(clip);
            }
        }
            if (source.isPlaying==false &&buttons[0].interactable==true )
        {
            source.PlayOneShot(clip);
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            if (rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text))
            {
                ColorBlock temp = buttons[i].colors;
                temp.disabledColor = new Color(20f / 255f, 235f / 255f, 0f / 255f);
                buttons[i].colors = temp;
            }
            if (!rightanswer.Equals(buttons[i].GetComponentInChildren<TMP_Text>().text))
            {
                ColorBlock temp = buttons[i].colors;
                temp.disabledColor = new Color(220f/255f,40f/255f,100f/255f);
                buttons[i].colors = temp;
            }

        }
        yield return new WaitForSeconds(1);
        if (PlayerPrefs.GetInt("item") >= main.questions.Length)
        {
            PlayerPrefs.SetInt("EndGame", 1);
        }
        if (PlayerPrefs.GetInt("EndGame") == 0)
        {
            NextQuestion.gameObject.SetActive(true);
        }
        else
        {
            NextQuestion.gameObject.SetActive(false);
            End.gameObject.SetActive(true);
        }
        yield return new WaitForEndOfFrame();

    }


}
