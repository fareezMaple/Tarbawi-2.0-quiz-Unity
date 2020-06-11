using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MCQGameManager : MonoBehaviour
{
    public MCQQuestions[] questions;
    private static List<MCQQuestions> unansweredQuestions;
    public static int scoreCounter; //pass ke MCQEndQuiz
    public static int correctCounter; //pass ke MCQEndQuiz
    public static int wrongCounter; //pass ke MCQEndQuiz
    public Button button1;
    public Button button2;
    public Button button3;
    public GameObject trueScreen;
    public GameObject wrongScreen;


    [SerializeField]
    private Animator screenAnim;

    private MCQQuestions currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestons = 2f;

    [SerializeField]
    private Text answer1;
    [SerializeField]
    private Text answer2;
    [SerializeField]
    private Text answer3;


    //[SerializeField]
    //private Animator animator;

    private void Start()
    {

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<MCQQuestions>(); //bende ni execute selepas if, sptutnye sbeum if   
        }
        trueScreen.SetActive(false);
        wrongScreen.SetActive(false);
        setCurrentQuestion();
        questionHasEnded();

        //Debug.Log(currentQuestion.fact + "is" + currentQuestion.isTrue);
    }

    public bool questionHasEnded()
    {
        bool status = unansweredQuestions == null || unansweredQuestions.Count == 0;

        return status;
    }



    void setCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        answer1.text = currentQuestion.answer1;
        answer2.text = currentQuestion.answer2;
        answer3.text = currentQuestion.answer3;


    }
    IEnumerator transitionToNextQuestion() //load next question/scene
    {
        unansweredQuestions.Remove(currentQuestion);


        if (!questionHasEnded()) //klw soalan belum habis, reload scene
        {
            yield return new WaitForSeconds(timeBetweenQuestons);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart level
        }

    }
    
    //Below is button OnClick Events
    public void UserSelectAnswer1()
    {

        if (currentQuestion.isTrue1)
        {
            FindObjectOfType<AudioManager>().Play("CorrectTone");
            Debug.Log("Correct"); //can add score to this later and maybe audio
            trueScreen.SetActive(true);
            screenAnim.SetTrigger("correct");
            scoreCounter += 1; //tukar jadi factor of time
            correctCounter += 1;
            
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("WrongTone");
            Debug.Log("Wrong");
            wrongScreen.SetActive(true);
            screenAnim.SetTrigger("wrong");
            if (currentQuestion.isTrue2) button2.image.color = Color.green;
            if (currentQuestion.isTrue3) button3.image.color = Color.green; //tunjuk jawapan mana betul
            wrongCounter += 1;

        }
        StartCoroutine(transitionToNextQuestion());

    }

    public void UserSelectAnswer2()
    {

        if (currentQuestion.isTrue2)
        {
            FindObjectOfType<AudioManager>().Play("CorrectTone");
            Debug.Log("Correct");
            trueScreen.SetActive(true);
            screenAnim.SetTrigger("correct");
            scoreCounter += 1;
            correctCounter += 1;
            
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("WrongTone");
            Debug.Log("Wrong");
            wrongScreen.SetActive(true);
            screenAnim.SetTrigger("wrong");
            if (currentQuestion.isTrue1) button1.image.color = Color.green;
            if (currentQuestion.isTrue3) button3.image.color = Color.green;
            wrongCounter += 1;
        }

        StartCoroutine(transitionToNextQuestion());
    }

    public void UserSelectAnswer3()
    {

        if (currentQuestion.isTrue3)
        {
            FindObjectOfType<AudioManager>().Play("CorrectTone");
            Debug.Log("Correct");
            trueScreen.SetActive(true);
            screenAnim.SetTrigger("correct");
            scoreCounter += 1;
            correctCounter += 1;
            
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("WrongTone");
            Debug.Log("Wrong");
            wrongScreen.SetActive(true);
            screenAnim.SetTrigger("wrong");
            if (currentQuestion.isTrue2) button2.image.color = Color.green;
            if (currentQuestion.isTrue1) button1.image.color = Color.green;
            wrongCounter += 1;
        }
        StartCoroutine(transitionToNextQuestion());

    }
}
