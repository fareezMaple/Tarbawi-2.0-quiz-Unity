using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    public void userSelectResume() //utk resume button
    {
        pauseScreen.SetActive(false);
    }

    public void userSelectPause() //utk pause button
    {
        pauseScreen.SetActive(true);
    }

    public void userSelectMenu()
    {
        SceneManager.LoadScene("MAINMENU", LoadSceneMode.Single);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
