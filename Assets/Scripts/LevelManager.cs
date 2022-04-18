using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public MainMenuManager main;

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Back()
    {
        main.lPanel.SetActive(false);
        main.mPanel.SetActive(true);
        main.videoPlayer.SetActive(true);
    }
}
