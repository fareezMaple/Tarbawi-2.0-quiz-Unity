using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBarManager : MonoBehaviour
{
    public void openUrl(string URL)
    {
        Application.OpenURL(URL);
        Debug.Log("open url: " + URL);
    }
}
