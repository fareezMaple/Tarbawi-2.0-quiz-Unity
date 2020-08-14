using System;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizStatistic : MonoBehaviour
{
    public static QuizStatistic instance;

    private GameObject statButton;
    private GameObject buttonClosePanel;
    
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
        
        buttonClosePanel = GameObject.Find("ClosePanelButton");
        buttonClosePanel.GetComponentInChildren<Button>().onClick.AddListener(() => hideStatPanel());
        
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

        if (Social.localUser.authenticated && _correctCount == 8) //user get full marks
        {
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_smart, 1, success =>
            {
                Debug.Log("Smart achievement " + success);
            });
        }
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

        LeanTween.moveY(statPanel.GetComponent<RectTransform>(), 110f, .5f).setEase(LeanTweenType.easeInExpo);
        totalCorrectText.text = totalCorrectCount.ToString();
        totalWrongText.text = totalWrongCount.ToString();
        totalAllText.text = (totalCorrectCount + totalWrongCount).ToString();


    }

    public void hideStatPanel()
    {
        LeanTween.moveY(statPanel.GetComponent<RectTransform>(), 700f, .5f).setEase(LeanTweenType.pingPong);
    }

}
