using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mPanel;
    public GameObject lPanel;
    public GameObject oPanel;
    public GameObject sPanel;

    public GameObject videoPlayer;

    public void Play()
    {
        videoPlayer.SetActive(false);
        mPanel.SetActive(false);
        lPanel.SetActive(true);
    }

    public void Options()
    {
        mPanel.SetActive(false);
        oPanel.SetActive(true);
    }

    public void OptionBack()
    {
        oPanel.SetActive(false);
        mPanel.SetActive(true);
    }

    public void Shop()
    {
        videoPlayer.SetActive(false);
        mPanel.SetActive(false);
        sPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
