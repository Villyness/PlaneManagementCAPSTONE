using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool handsFull; //if they're holding something
    public string holding;  //what object the player is holding - if nothing is null
    public int score;

    public void Start()
    {
        score = 0;
    }

    public void ScoreIncrease()
    {
        score += 1;
    }

}
