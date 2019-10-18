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
    private Canvas ownCanvas;
    public CanvasGroup PausePanel;
    public CanvasGroup AudioSettingsPanel;
    private bool IsPaused;

    public int LevelSelectIndex;
    
    // 
    void Start()
    {
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().Pause += TogglePause;

        ownCanvas = GetComponent<Canvas>();
        ownCanvas.enabled = true;
        StartCoroutine(Deactivate(AudioSettingsPanel));
        StartCoroutine(Deactivate(PausePanel));
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
        //ownCanvas.enabled = true;
        StartCoroutine(Activate(PausePanel));
        StartCoroutine(Deactivate(AudioSettingsPanel));
        Time.timeScale = 0f;    // ZA WARUDOOOOOOO
        IsPaused = true;
    }

    public void ResumeGame()
    {
        //ownCanvas.enabled = false;
        StartCoroutine(Deactivate(PausePanel));
        StartCoroutine(Deactivate(AudioSettingsPanel));
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

    public void ToAudioSettingsMenu()
    {
        StartCoroutine(Deactivate(PausePanel));
        StartCoroutine(Activate(AudioSettingsPanel));
    }

    IEnumerator Activate(CanvasGroup _panel)
    {
        while (_panel.alpha < 1)
        {
            _panel.alpha = 1;
            yield return null;
        }
        _panel.interactable = true;
        _panel.blocksRaycasts = true;
        yield return null;
    }

    IEnumerator Deactivate(CanvasGroup _panel)
    {
        while (_panel.alpha > 0)
        {
            _panel.alpha = 0;
            yield return null;
        }
        _panel.interactable = false;
        _panel.blocksRaycasts = false;
        yield return null;
    }
}
