using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStatistic : MonoBehaviour
{
    //playerPref use
    public string TOTAL_CORRECT_ANSWER = "TotCorAns";
    public string TOTAL_WRONG_ANSWER = "TotWorAns";

    private int totalCorrectCount;
    private int totalWrongCount;

    public void setTotalCorect(int _totalCorrectCount)
    {
        totalCorrectCount += _totalCorrectCount;
    }
    
    public void setWrongCorect(int _totalWrongCount)
    {
        totalWrongCount += _totalWrongCount;
    }

    public void showQuizStat()
    {
        int totalALlAnswerCount = totalCorrectCount + totalWrongCount;
        Debug.Log("Correct ans is: " + totalCorrectCount + ", wrong answer is: " + 
                  totalWrongCount + ", total is: " + totalALlAnswerCount);
        
        
    }
}
