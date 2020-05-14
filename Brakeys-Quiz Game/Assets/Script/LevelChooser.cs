using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour
{
    //TF is true or false.
    //MCQ is multiple choice

    public void TFlevel(string SceneName)
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        SceneManager.LoadScene(SceneName);
        
    }
    public void MCQlevel(string SceneName)
    {
        FindObjectOfType<AudioManager>().Play("PressTone");
        SceneManager.LoadScene(SceneName);
    }
}
