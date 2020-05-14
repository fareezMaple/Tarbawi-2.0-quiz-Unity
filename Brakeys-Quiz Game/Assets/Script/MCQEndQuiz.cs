using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MCQEndQuiz : MonoBehaviour
{
    public GameObject screen;
    public Text scoreText;
    public Text correctText; //counter
    public Text wrongText; //counter

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkStatus();
    }

    private void checkStatus()
    {
        if (FindObjectOfType<MCQGameManager>().questionHasEnded())
        {
            Invoke("showEndScreen", 1.3f); //tunggu sebentar utk show screen
        }

    }

    private void showEndScreen()
    {
        screen.SetActive(true);
        showScore();
        //maybe boleh add sound
    }

    private void showScore() //score and another counter
    {
        scoreText.text = "Score: " + MCQGameManager.scoreCounter.ToString();  //dpt dari variable dlm GameManager
        correctText.text = "Jawapan betul: " + MCQGameManager.correctCounter.ToString();
        wrongText.text = "Jawapan salah: " + MCQGameManager.wrongCounter.ToString();
        //probably add particle ssytem
    }

    private void resetAllCounter()
    {
        MCQGameManager.scoreCounter = 0;
        MCQGameManager.correctCounter = 0;
        MCQGameManager.wrongCounter = 0;
    }

    public void userSelectContinue()
    {
        //Debug.Log("Contniue levelll");
        resetAllCounter();
    }

    public void userSelectMenu()
    {
        SceneManager.LoadScene("MAINMENU", LoadSceneMode.Single);
        resetAllCounter();
    }

    public void userSelectRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resetAllCounter();
    }  
}
