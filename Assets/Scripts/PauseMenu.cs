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

    // This is pretty much an UI Manager now 

    // Setting up...
    private Canvas ownCanvas;
    public CanvasGroup PausePanel;
    public CanvasGroup AudioSettingsPanel;
    public CanvasGroup GameUIPanel;
    public CanvasGroup MainMenuPanel;
    [Range(0.3f, 1f)]public float transitionSpeed;
    private bool IsPaused;

    public int LevelSelectIndex;


    void Start()
    {
        ownCanvas = GetComponent<Canvas>();
        ownCanvas.enabled = true;
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartCoroutine(Deactivate(AudioSettingsPanel)); // deactivate all the panels, only show StartMenu
        StartCoroutine(Deactivate(PausePanel));
        StartCoroutine(Deactivate(GameUIPanel));
        StartCoroutine(Activate(MainMenuPanel));

        IsPaused = false;
    }

    // Check if the active scene is StartMenu, 
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // make sure the game isn't paused
        Time.timeScale = 1.0f;
        IsPaused = false;
        // if active scene isn't StartMenu, activate GameUI
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartCoroutine(Activate(GameUIPanel));
        }

        Debug.Log("OnSceneLoaded: " + scene.name);
        //Debug.Log("mode: " + mode);
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
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
        StartCoroutine(Activate(PausePanel));
        StartCoroutine(Deactivate(AudioSettingsPanel));
        StartCoroutine(Deactivate(GameUIPanel));
        Time.timeScale = 0f;    // ZA WARUDOOOOOOO
        IsPaused = true;
    }

    public void ResumeGame()
    {
        StartCoroutine(Deactivate(PausePanel));
        StartCoroutine(Deactivate(AudioSettingsPanel));
        StartCoroutine(Activate(GameUIPanel));
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Set music to start of level loop... and it didn't work
        AudioManager.instance.GameplayStart();
        ResumeGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        // if it's not start menu
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(LevelSelectIndex);
            StartCoroutine(Activate(MainMenuPanel));
            StartCoroutine(Deactivate(PausePanel));
            StartCoroutine(Deactivate(AudioSettingsPanel));
            StartCoroutine(Deactivate(GameUIPanel));
            // Set Music back to start menu music
            AudioManager.instance.StartMenu();
        }
        else
        {
            StartCoroutine(Deactivate(MainMenuPanel));
        }
    }

    public void FullscreenToggle(bool isFullScr)
    {
        Screen.fullScreen = isFullScr;
        Debug.Log(isFullScr);
    }

    public void ToAudioSettingsMenu()
    {
        StartCoroutine(Deactivate(PausePanel));
        StartCoroutine(Deactivate(MainMenuPanel));
        StartCoroutine(Activate(AudioSettingsPanel));
    }

    public void CloseAudioMenu()
    {
        StartCoroutine(Deactivate(AudioSettingsPanel));

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartCoroutine(Activate(PausePanel));
        }
        else
        {
            StartCoroutine(Activate(MainMenuPanel));
        }
    }

    IEnumerator Activate(CanvasGroup _panel) // Show the canvas group by changing the alpha to 1
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

    IEnumerator Deactivate(CanvasGroup _panel) // Hide the canvas group by changing the alpha to 0
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
