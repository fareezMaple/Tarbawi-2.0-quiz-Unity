using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator pushPanel;
    public GameObject screenTrueOrFalse;
    public GameObject screenMultipleChoice;
    public GameObject infoPanel;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }
    public void userSelectStart()
    {
        pushPanel.SetTrigger("PUSH");
        FindObjectOfType<AudioManager>().Play("PressTone");
    }

    public void userSelectExit()
    {
        SceneManager.LoadScene("EXIT SCENE", LoadSceneMode.Additive); //to exit screen
        FindObjectOfType<AudioManager>().Play("PressTone");
    }

    public void userSelectBack () //in choose mode panel
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        pushPanel.SetTrigger("PULL");
    }

    public void userSelectTrueOrFalse()
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        screenTrueOrFalse.SetActive(true);
    }
    public void userSelectBack2() //utk screen true false
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        screenTrueOrFalse.SetActive(false);
    }
    public void userSelectMultipleChoice()
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        screenMultipleChoice.SetActive(true);
    }
    public void userSelectBack3() //utk screen multiple choice
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        screenMultipleChoice.SetActive(false);
    }
}
