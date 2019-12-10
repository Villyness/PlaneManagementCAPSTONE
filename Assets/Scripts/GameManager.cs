﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public int levelIndex;

    [Header("Debug")]
    public Text audioText;

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
        // Audio Debug
        //audioText = GetComponentInChildren<Text>();


        hostessAnim.start = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        // For audio debug. show progression value on screen. 
        //audioText.text = "Progression: " + AudioManager.progression.ToString();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (hostessAnim != null)
            hostessAnim.start = true;
        player = FindObjectOfType<PlayerMovement>();
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += DisableInput;

        if (LevelSelectMenu != null)
            LevelSelectMenu.SetActive(false);

        // if it's start menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            MainMenu.SetActive(true);
            AudioManager.instance.planeTakeOff.setParameterByID(AudioManager.instance.pTOID, 0);
            AudioManager.instance.planeAtmos.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            AudioManager.instance.flightAttendantWelcome.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else
        {
            AudioManager.instance.PlaneTakeOff();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: levelIndex);
    }

    public void ToLevelSelectFromStart()
    {
        animator_startToLevelSelect.SetTrigger("Start");
        LevelSelectMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    void DisableInput()
    {
        player.enabled = false;
    }
}
