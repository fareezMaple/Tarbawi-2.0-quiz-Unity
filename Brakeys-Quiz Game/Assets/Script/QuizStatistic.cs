using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizStatistic : MonoBehaviour
{
    public static QuizStatistic instance;

    private GameObject statButton;
    private GameObject buttonResetAllStats;
    
    public GameObject statPanel;
    public Text totalCorrectText;
    public Text totalWrongText;
    public Text totalAllText;

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
        Debug.Log("OnFinishLevelLoadingCalled");
    } 

    private void addListener()
    {
        statButton = GameObject.Find("List Item stat");
        statButton.GetComponent<Button>().onClick.AddListener(() => showQuizStat());
        
        buttonResetAllStats = GameObject.Find("DeleteAllButton");
        buttonResetAllStats.GetComponentInChildren<Button>().onClick.AddListener(() => deleteAllStats());
        
        statPanel = GameObject.Find("StatistikPanel");
        totalCorrectText = GameObject.Find("jumlah soalan betul").GetComponent<Text>();
        totalWrongText = GameObject.Find("jumlah soalan salah").GetComponent<Text>();
        totalAllText = GameObject.Find("jumlah semua soalan").GetComponent<Text>();


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
        int allAnswerCount = totalCorrectCount + totalWrongCount;
        Debug.Log("Correct ans is: " + totalCorrectCount + ", wrong answer is: " + 
                  totalWrongCount + ", total is: " + allAnswerCount);

        statPanel.SetActive(true);
        //TODO: assign all text and stuff
    }

    public void deleteAllStats()
    {
        PlayerPrefs.DeleteKey(TOTAL_WRONG_ANSWER);
        PlayerPrefs.DeleteKey(TOTAL_CORRECT_ANSWER);
        Debug.Log("Deleted all stats");
    }

}
