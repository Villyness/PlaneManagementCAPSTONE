using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitscript : MonoBehaviour
{

    private void Start()
    {
        PauseMenu.audiosettingsorsomething += whater;
    }

    public void whater()
    {
        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
    }
}
