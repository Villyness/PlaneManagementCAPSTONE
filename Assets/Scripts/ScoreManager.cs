using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int level = 1;    // Setting it to 1 so that it won't get any out of range errors
    public int score;

    //for each level go through and set individually
    public int[] passScore = {100,150,200,250,300};
    public int[] goodScore = {150,200,250,300,350};
    public int[] bestScore = {200,250,300,350,400};

    //stars for winning
    public GameObject passStar;
    public GameObject goodStar;
    public GameObject bestStar;

    public Material matPass;
    public Material matFail;
    
    //popup game menu
    public GameObject endScreen;

    public bool passed;
    
    //make an LevelEnds event that ScoreManager listens for, on the event go to Level End.
    //the following is just a debug version of that because the level doesn't yet have a timer
    public bool ended;

    void Start()
    {
        ScoreReset();
    }

    void ScoreReset()
    {
        score = 0;
        //this makes it a pop up rather than a seperate screen
        bestStar.GetComponent<Renderer>().material = matFail;
        goodStar.GetComponent<Renderer>().material = matFail;
        passStar.GetComponent<Renderer>().material = matFail;
        endScreen.GetComponent<Renderer>().enabled = false;
        bestStar.GetComponent<Renderer>().enabled = false;
        goodStar.GetComponent<Renderer>().enabled = false;
        passStar.GetComponent<Renderer>().enabled = false;
    }

    private void Update()
    {
        if (ended)
        {
            LevelEnd();
        }
    }

    void LevelEnd()
    {
        endScreen.GetComponent<Renderer>().enabled = true;
        bestStar.GetComponent<Renderer>().enabled = true;
        goodStar.GetComponent<Renderer>().enabled = true;
        passStar.GetComponent<Renderer>().enabled = true;
        
        //check score, have gameobjects for each.
        if (score >= bestScore[level])
        {
            passed = true;
            bestStar.GetComponent<Renderer>().material = matPass;
            //best score
        }
        if (score >= goodScore[level])
        {
            passed = true;
            
            goodStar.GetComponent<Renderer>().material = matPass;
            //good score
        }
        if (score >= passScore[level])
        {
            passed = true;
            passStar.GetComponent<Renderer>().material = matPass;
            //passed
        }
        else
        {
            
            //failed
        }

        /*if (passed)
        {
            level++;
            ScoreReset();
            //load next level
        }*/
    }
}
