using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager AudioManager;

    private PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += DisableInput;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1); // For now. Need to change it later to detect which level player chose.
        AudioManager.GameplayStart();
    }

    void DisableInput()
    {
        player.enabled = false;
    }

}
