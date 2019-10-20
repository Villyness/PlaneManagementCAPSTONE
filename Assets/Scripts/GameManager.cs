using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager AudioManager;
    public Animator animator_startToLevelSelect;

    private PlayerMovement player;

    public GameObject MainMenu; // will probably change this to using canvas groups instead 
    public GameObject LevelSelectMenu;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += DisableInput;

        if (FindObjectOfType<LevelSelect>())
            LevelSelectMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1); // For now. Need to change it later to detect which level player chose.
        AudioManager.GameplayStart();
    }

    public void ToLevelSelectFromStart()
    {
        animator_startToLevelSelect.SetTrigger("Start");
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }

    void DisableInput()
    {
        player.enabled = false;
    }
}
