using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine("quitGame");
        }
        
    }
    IEnumerator quitGame()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
    public void quitGamePerButton()
    {
        Application.Quit();
    }
}
