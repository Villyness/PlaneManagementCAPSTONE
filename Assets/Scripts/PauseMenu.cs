using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // This is the script that handles the code for the PauseMenu
    // V's script so if it spontaneously combusts or looks like gibberish, @ me
    // Also go play Skullgirls IT'S GOOD
    
    // Setting up...
    private Canvas ownCanvas;
    private bool IsPaused;
    
    // 
    void Start()
    {
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().Pause += TogglePause;

        ownCanvas = GetComponent<Canvas>();

        ownCanvas.enabled = false;
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
        ownCanvas.enabled = true;
        Time.timeScale = 0f;    // ZA WARUDOOOOOOO
        IsPaused = true;
    }

    public void ResumeGame()
    {
        ownCanvas.enabled = false;
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }
}
