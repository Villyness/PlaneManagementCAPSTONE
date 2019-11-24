using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartMenu : MonoBehaviour
{
    // This script pretty much links all the public references back 
    // So things won't break after you come back to start menu from game

    public Animator amin;
    public GameObject LevelSelectMenu;
    public LevelSelect LevelSelect;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.animator_startToLevelSelect = amin;
        GameManager.instance.LevelSelectMenu = LevelSelectMenu;
        //GameManager.instance.levelSelect = LevelSelect;
    }

    public void LaunchFlight()
    {
        GameManager.instance.PlayGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
