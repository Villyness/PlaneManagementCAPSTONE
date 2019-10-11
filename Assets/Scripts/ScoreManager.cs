using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class ScoreManager : MonoBehaviour
{
    //TODO: <pr> = set to private after testing
    public int level = 0;    // Setting it to 1 so that it won't get any out of range errors
    public int score;

    //for each level go through and set individually
    public int[] passScore = {100,150,200,250,300};
    public int[] goodScore = {150,200,250,300,350};
    public int[] bestScore = {200,250,300,350,400};

    //stars for winning <pr>
    public UnityEngine.UI.Image passStar;
    public UnityEngine.UI.Image goodStar;
    public UnityEngine.UI.Image bestStar;

    // <pr>
    public Material matPass;
    public Material matFail;
    
    //popup game menu <pr>
    public GameObject endScreen;

    public bool passed;

    public Text finalScore;
    
    //make an LevelEnds event that ScoreManager listens for, on the event go to Level End.
    //the following is just a debug version of that because the level doesn't yet have a timer
    public bool ended;

    void Start()
    {
        if (FindObjectOfType<LevelManager>())
        {
            FindObjectOfType<LevelManager>().LevelEnded += LevelEnd;
        }
        else
        {
            return;        
        }

        foreach (InteractCustomer passenger in FindObjectsOfType<InteractCustomer>())
        {
            passenger.PointsAwarded += UpdateScore;
        }

        
        //ScoreReset();
    }

    /*void ScoreReset()
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
    }*/

    private void Update()
    {
        if (ended)
        {
            //LevelEnd();
        }
    }

    void LevelEnd()
    {
        //passStar.color = Color.yellow;
        
        /*endScreen.GetComponent<Renderer>().enabled = true;
        bestStar.GetComponent<Renderer>().enabled = true;
        goodStar.GetComponent<Renderer>().enabled = true;
        passStar.GetComponent<Renderer>().enabled = true;*/
        Debug.Log(passScore[level]);
        //check score, have gameobjects for each.
        if (score >= bestScore[level])
        {
            //passed = true;
            //bestStar.GetComponent<Renderer>().material = matPass;
            //best score
            bestStar.color = Color.yellow;
        }
        if (score >= goodScore[level])
        {
            //passed = true;
            goodStar.color = Color.yellow;
            //goodStar.GetComponent<Renderer>().material = matPass;
            //good score
        }
        if (score >= passScore[level])
        {
            passStar.color = Color.yellow;
            
            passed = true;
            //passStar.GetComponent<Renderer>().material = matPass;
            //passed
        }
        else
        {
            passed = false;
            //failed
        }

        /*if (passed)
        {
            level++;
            ScoreReset();
            //load next level
        }*/

        GetComponent<Canvas>().enabled = true;
        finalScore.text = "Score: " + score;
        //Debug.Log("Determination");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
    }
}
