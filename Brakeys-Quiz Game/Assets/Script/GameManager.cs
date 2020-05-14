using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Questions[] questions;
    private static List<Questions> unansweredQuestions;
    public static int correctCounter; //pass ke EndQuiz
    public static int wrongCounter; //pass ke EndQuiz


    private Questions currentQuestion;
    
    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestons = 1f;

    [SerializeField] //response answer
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Questions>(); //bende ni execute selepas if, sptutnye sbeum if   
        }
        setCurrentQuestion();
        questionHasEnded();        //check status

        //Debug.Log(currentQuestion.fact + "is" + currentQuestion.isTrue);
    }

    public bool questionHasEnded()
    {
        bool status = false;
        
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            status = true;
        }
        return status;
    }



    void setCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue) //RESPONSE
        {
            trueAnswerText.text = "BETUL";
            falseAnswerText.text = "SALAH";
        } else
        {
            trueAnswerText.text = "SALAH";
            falseAnswerText.text = "BETUL";
        }

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

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            FindObjectOfType<AudioManager>().Play("CorrectTone");
            Debug.Log("Correct"); //can add score to this later and maybe audio
            correctCounter += 1;
        } else
        {
            FindObjectOfType<AudioManager>().Play("WrongTone");
            Debug.Log("Wrong");
            wrongCounter += 1;
        }

        StartCoroutine(transitionToNextQuestion());
    }

    //Below is button OnClick Events
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            FindObjectOfType<AudioManager>().Play("CorrectTone");
            Debug.Log("Correct");
            correctCounter += 1;
        } else
        {
            FindObjectOfType<AudioManager>().Play("WrongTone");
            Debug.Log("Wrong");
            wrongCounter += 1;
        }

        StartCoroutine(transitionToNextQuestion());
    }

    

}