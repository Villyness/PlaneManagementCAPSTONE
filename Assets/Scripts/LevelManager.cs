using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action LevelEnded; 
    public float timer;
    public float LevelTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        /*if (Interacted != null)
        {
            Interacted(this.gameObject);
            Debug.Log("Sent");
        }
        else
        {
            Debug.Log("Null!");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= LevelTimer)
        {
            if (LevelEnded != null)
                LevelEnded();

            timer = 0;
        }
    }
}
