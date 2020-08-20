using System;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MCQEndQuiz : MonoBehaviour
{
    public GameObject screen;
    public Text scoreText;
    public Text correctText; //counter
    public Text wrongText; //counter

    void Update()
    {
        if (!screen.activeSelf)
            checkStatus();
    }

    private void checkStatus()
    {
        if (FindObjectOfType<MCQGameManager>().questionHasEnded())
        {
            
            Invoke("showEndScreen", 1.2f); //tunggu sebentar utk show screen
        }

    }

    private void showEndScreen()
    {
        screen.SetActive(true);
        showScore();
        
        QuizStatistic.instance.addTotalQuizAnswered();
        //maybe boleh add sound
        
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_completed_first_quiz,100.0f,
                (bool success) =>
                {
                    Debug.Log("Welcome" + success);
                });
        }
    }

    private void showScore() //score and another counter
    {
        scoreText.text = "Score: " + MCQGameManager.scoreCounter;  //dpt dari variable dlm GameManager
        correctText.text = "Jawapan betul: " + MCQGameManager.correctCounter;
        wrongText.text = "Jawapan salah: " + MCQGameManager.wrongCounter;
        //probably add particle system
    }

    private void resetAllCounter()
    {
        MCQGameManager.scoreCounter = 0;
        MCQGameManager.correctCounter = 0;
        MCQGameManager.wrongCounter = 0;
    }

    private void setStatistik()
    {
        QuizStatistic.instance.addTotalCorect(MCQGameManager.correctCounter);
        QuizStatistic.instance.addWrongCorect(MCQGameManager.wrongCounter);
        Debug.Log("Statistik set to correct: " + MCQGameManager.correctCounter + ", wrong: " + MCQGameManager.wrongCounter);
    }

    public void userSelectContinue()
    {
        //Debug.Log("Contniue levelll");
        setStatistik();
        resetAllCounter();
    }

    public void userSelectMenu()
    {
        SceneManager.LoadScene("MAINMENU", LoadSceneMode.Single);
        setStatistik();
        resetAllCounter();
    }

    public void userSelectRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        setStatistik();
        resetAllCounter();
    }  
}
