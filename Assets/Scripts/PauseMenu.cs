using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // This is the script that handles the code for the PauseMenu
    // V's script so if it spontaneously combusts or looks like gibberish, @ me
    // Also go play Skullgirls IT'S GOOD
    
    // Setting up...
    private Canvas pauseCanvas;
    public Canvas AudioSettingsMenu;
    private bool IsPaused;

    public int LevelSelectIndex;
    
    // 
    void Start()
    {
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().Pause += TogglePause;

        pauseCanvas = GetComponent<Canvas>();

        pauseCanvas.enabled = false;
        //AudioSettingsMenu.enabled = false;
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {
        switch (IsPaused)
        {
            case true:
                ResumeGame();
                break;
            case false:
                PauseGame();
                break;
        }
    }

    public void PauseGame()
    {
        pauseCanvas.enabled = true;
        AudioSettingsMenu.enabled = false;
        Time.timeScale = 0f;    // ZA WARUDOOOOOOO
        IsPaused = true;
    }

    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(LevelSelectIndex);
        ResumeGame();
    }

    public void FullscreenToggle(bool isFullScr)
    {
        Screen.fullScreen = isFullScr;
        Debug.Log(isFullScr);
    }

    public delegate void Bic();
    public static Bic audiosettingsorsomething;

    public void ToAudioSettings()
    {
        audiosettingsorsomething?.Invoke();
        //AudioSettingsMenu.enabled = true;
    }


}
