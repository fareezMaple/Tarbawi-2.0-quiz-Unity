[System.Serializable]
public class Questions 
{
    public string fact;
    public bool isTrue;
}

[System.Serializable]
public class MCQQuestions
{
    public string fact;
    public string answer1;
    public bool isTrue1;
    public string answer2;
    public bool isTrue2;
    public string answer3;
    public bool isTrue3;
    //one question, three choices, one only correct
}
