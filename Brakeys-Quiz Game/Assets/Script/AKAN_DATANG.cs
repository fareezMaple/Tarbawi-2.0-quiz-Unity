using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKAN_DATANG : MonoBehaviour
{
    public GameObject aknDtgPanel;
    public void userPressOK()
    {
        aknDtgPanel.SetActive(false);
    }

    public void showPanel()
    {
        aknDtgPanel.SetActive(true);
    }
}
