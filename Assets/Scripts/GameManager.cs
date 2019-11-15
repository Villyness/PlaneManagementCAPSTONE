using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Header("Animators")]
    public Animator animator_startToLevelSelect;
    [Space]

    private PlayerMovement player;

    public GameObject MainMenu;
    public GameObject LevelSelectMenu;

    public static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

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
        AudioManager.instance.GameplayStart();
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
