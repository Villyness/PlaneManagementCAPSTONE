using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioManager AudioManager;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1); // For now. Need to change it later to detect which level player chose.
        AudioManager.GameplayStart();
    }

}
