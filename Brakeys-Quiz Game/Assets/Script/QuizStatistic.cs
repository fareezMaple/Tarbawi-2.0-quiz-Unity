using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizStatistic : MonoBehaviour
{
    //playerPref use
    private string TOTAL_CORRECT_ANSWER = "TotCorAns";
    private string TOTAL_WRONG_ANSWER = "TotWorAns";

    private int totalCorrectCount;
    private int totalWrongCount;

    public void addTotalCorect(int _correctCount)
    {
        totalCorrectCount += _correctCount;
    }
    
    public void addWrongCorect(int _wrongCount)
    {
        totalWrongCount += _wrongCount;
    }

    public void showQuizStat()
    {
        int totalALlAnswerCount = totalCorrectCount + totalWrongCount;
        Debug.Log("Correct ans is: " + totalCorrectCount + ", wrong answer is: " + 
                  totalWrongCount + ", total is: " + totalALlAnswerCount);
        
    }

}
