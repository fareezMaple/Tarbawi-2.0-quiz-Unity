using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{
    private Text signInButtonText;
    private Text authText;
    
    // Start is called before the first frame update
    void Start()
    {
        signInButtonText = GameObject.Find("SignInButton").GetComponentInChildren<Text>();
        authText = GameObject.Find("authStatus").GetComponent<Text>();
        
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.DebugLogEnabled = true;
        
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
        
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Signed in!");
            signInButtonText.text = "Sign out";

            authText.text = "Signed in as " + Social.localUser.userName;
        }
        else
        {
            Debug.Log("Sign in failed");
            signInButtonText.text = "Sign in";
            authText.text = "Login failed!";
        }
    }

    public void SignIn()
    {
        Debug.Log("clicked!!");
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            PlayGamesPlatform.Instance.SignOut();
            
            //RESET UI
            Debug.Log("UI resetted");
            signInButtonText.text = "Sign in";
            authText.text = "";
        }
    }
}
