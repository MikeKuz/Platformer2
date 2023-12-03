using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject losePanel;

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
        FreezeTime();
    }

    public void HideLosePanle()
    {
        losePanel.SetActive(false);
    }

    public void FreezeTime()
    {
        Time.timeScale = 0;
    }

    public void UnfreezeTime()
    {
        Time.timeScale = 1f;


    }
}
