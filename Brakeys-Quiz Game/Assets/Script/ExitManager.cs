using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public GameObject trueText;
    public GameObject falseText;
    private float delayTime = 1f;
    public Animator animator;

    public void userSelectYes()
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        animator.SetTrigger("True");
        trueText.SetActive(false);
        falseText.SetActive(true);
        Invoke("exitThisGame", delayTime);
    }

    public void userSelectNo()
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        animator.SetTrigger("False");
        trueText.SetActive(true);
        falseText.SetActive(false);
        Invoke("returnToMainMenu", delayTime);

    }

    private void exitThisGame()
    {
        Debug.Log("babai exit game niii");
        Application.Quit();

    }

    private void returnToMainMenu()
    {
        
        Debug.Log("Welcome back to MAIN MENU ni");

        SceneManager.LoadScene(0); //to main menu
    }
}
