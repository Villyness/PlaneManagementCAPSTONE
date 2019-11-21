using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Animators")]
    public Animator animator_startToLevelSelect;
    public HostessAnim hostessAnim;

    [Space]

    private PlayerMovement player;

    [Header("Level Select")]
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;
    public LevelSelect levelSelect;
    public int levelIndex;

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
        hostessAnim.start = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (hostessAnim != null)
            hostessAnim.start = true;
        player = FindObjectOfType<PlayerMovement>();
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += DisableInput;

        //if (FindObjectOfType<LevelSelect>())
        if (LevelSelectMenu != null)
            LevelSelectMenu.SetActive(false);

    }

    public void PlayGame()
    {
        AudioManager.instance.GameplayStart();
        SceneManager.LoadScene(sceneBuildIndex: levelIndex);
    }

    public void ToLevelSelectFromStart()
    {
        animator_startToLevelSelect.SetTrigger("Start");
        //MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }

    void DisableInput()
    {
        player.enabled = false;
    }
}
