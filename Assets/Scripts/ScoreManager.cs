using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    //TODO: <pr> = set to private after testing
    public int level;
    public int score;

    [Space]
    [Header("Score Requirements")]
    //for each level go through and set individually
    public int[] passScore = {100,150,200,250,300};
    public int[] goodScore = {150,200,250,300,350};
    public int[] bestScore = {200,250,300,350,400};

    [Space]
    [Header("Public References")]
    public Text finalScore;
    public GameObject NextLevel;
    public bool ShowScore = false;
    public GameObject ScoreCanvas;
    public RectTransform PassportPos;
    public StampingAnim StampAnim;
    public float duration = 1;

    [Space]
    [Header("Star Particle References")]
    public ParticleSystem starParticles1;
    public ParticleSystem starParticles2;
    public ParticleSystem starParticles3;
    public float interval = .5f;

    [Space]
    [Header("Camera Shake Reference")]
    public float strength = 4f;
    public int vibrato = 30;



    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        finalScore.GetComponent<Text>().enabled = false;
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

    void LevelEnd()
    {
        ShowScore = true;
        PassportPos.DOAnchorPos(Vector3 .zero, 1f).SetEase(Ease.OutBounce).OnComplete(()=> ShowScoreInfo());
        //ScoreCanvas.SetActive(true);

        Debug.Log(passScore[level]);
        //check score, have gameobjects for each.
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
    }

    // contains info to show on score canvas. i.e. Score, Stamp Rating
    void ShowScoreInfo()
    {
        if (score >= bestScore[level])
        {
            // Do the stamping animation for all three star
            BestStampingAmin();
        }
        if (score >= goodScore[level])
        {
            // Do the stamping animation for first and second star
            GoodStampingAmin();
        }
        if (score >= passScore[level])
        {
            // Do the stamping animation for first star
            PassStampingAmin();
        }
        else
        {
            NextLevel.gameObject.SetActive(false);
            //failed
        }

        /*if (passed)
        {
            level++;
            ScoreReset();
            //load next level
        }*/

        GetComponent<Canvas>().enabled = true;
        finalScore.text = ""+ score;
        finalScore.GetComponent<Text>().enabled = true;

        //Debug.Log("Determination");

    }

    void PassStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));
    }

    void GoodStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp2.DOLocalMoveZ(0, duration).OnComplete(() => starParticles2.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));
    }

    void BestStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp2.DOLocalMoveZ(0, duration).OnComplete(() => starParticles2.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp3.DOLocalMoveZ(0, duration).OnComplete(() => starParticles3.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, strength, vibrato, 45, false));

    }

}
