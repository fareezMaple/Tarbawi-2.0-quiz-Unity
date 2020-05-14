using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndQuiz : MonoBehaviour
{
    public GameObject screen;
    public Text correctText;
    public Text wrongText;
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
        if (FindObjectOfType<GameManager>().questionHasEnded())
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

    private void showScore()
    {
        correctText.text = "Jawapan betul: " + GameManager.correctCounter.ToString();
        wrongText.text = "Jawapan salah: " + GameManager.wrongCounter.ToString();
    }

    private void resetAllCounter()
    { 
        GameManager.correctCounter = 0;
        GameManager.wrongCounter = 0;
    }

    public void userSelectContinue()
    {
        Debug.Log("Contniue levelll");
        resetAllCounter();
    }

    public void userSelectMenu ()
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
