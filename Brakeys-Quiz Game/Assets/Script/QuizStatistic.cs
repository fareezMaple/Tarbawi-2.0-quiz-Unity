using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizStatistic : MonoBehaviour
{
    public static QuizStatistic instance;

    private GameObject statButton;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        totalCorrectCount = PlayerPrefs.GetInt(TOTAL_CORRECT_ANSWER);
        totalWrongCount = PlayerPrefs.GetInt(TOTAL_WRONG_ANSWER);
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += onLevelFinishLoading;
    }

    void onLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        addListener();
        Debug.Log("Method level called");
    } 

    private void addListener()
    {
        statButton = GameObject.Find("List Item stat");
        statButton.GetComponent<Button>().onClick.AddListener((() => showQuizStat()));
    }

    //playerPref use
    private string TOTAL_CORRECT_ANSWER = "TotCorAns";
    private string TOTAL_WRONG_ANSWER = "TotWorAns";

    private int totalCorrectCount;
    private int totalWrongCount;

    public void addTotalCorect(int _correctCount)
    {
        totalCorrectCount += _correctCount;
        PlayerPrefs.SetInt(TOTAL_CORRECT_ANSWER, totalCorrectCount);
    }
    
    public void addWrongCorect(int _wrongCount)
    {
        totalWrongCount += _wrongCount;
        PlayerPrefs.SetInt(TOTAL_WRONG_ANSWER, totalWrongCount);
    }

    public void showQuizStat()
    {
        int totalALlAnswerCount = totalCorrectCount + totalWrongCount;
        Debug.Log("Correct ans is: " + totalCorrectCount + ", wrong answer is: " + 
                  totalWrongCount + ", total is: " + totalALlAnswerCount);
        
    }

}
