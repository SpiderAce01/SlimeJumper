using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioMixer mixer;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("Audio", Mathf.Log10(sliderValue) * 20);
    }
}
