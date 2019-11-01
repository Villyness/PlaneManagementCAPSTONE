using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalShortcuts : MonoBehaviour
{
    // This script contains code fo the global shortcuts (social media, pausing the game etc.)
    // V's script yet again so @me in discord
    // Ya ever notice you can't really lick your elbows?
    // And that 90% of you will attempt to do so after reading that^?

    public event Action PauseGame;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void EventToPause()
    {
        if (PauseGame != null)
            PauseGame();
        ;
    }
}
