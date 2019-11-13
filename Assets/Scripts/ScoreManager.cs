using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
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

    //stars for winning <pr>
    public UnityEngine.UI.Image passStar;
    public UnityEngine.UI.Image goodStar;
    public UnityEngine.UI.Image bestStar;

    [Space]
    [Header("Public References")]
    public Text finalScore;
    public GameObject NextLevel;
    public bool ShowScore = false;
    public GameObject ScoreCanvas;
    public RectTransform ScoreBackground;
    public StampingAnim StampAnim;
    public float duration = 1;

    [Space]
    [Header("Star Particle References")]
    public ParticleSystem starParticles1;
    public ParticleSystem starParticles2;
    public ParticleSystem starParticles3;
    public float interval = .5f;



    void Start()
    {
        //ScoreCanvas.SetActive(false);
        GetComponent<Canvas>().enabled = false;
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
        ScoreBackground.DOAnchorPos(Vector2.zero, 1f).SetEase(Ease.OutBounce).OnComplete(()=> ShowScoreInfo());
        //ScoreCanvas.SetActive(true);
        //passStar.color = Color.yellow;

        /*endScreen.GetComponent<Renderer>().enabled = true;
        bestStar.GetComponent<Renderer>().enabled = true;
        goodStar.GetComponent<Renderer>().enabled = true;
        passStar.GetComponent<Renderer>().enabled = true;*/
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
            //passed = true;
            //bestStar.GetComponent<Renderer>().material = matPass;
            //best score
            bestStar.color = Color.yellow;
            // Do the stamping animation for all three star
            BestStampingAmin();
        }
        if (score >= goodScore[level])
        {
            //passed = true;
            goodStar.color = Color.yellow;
            //goodStar.GetComponent<Renderer>().material = matPass;
            //good score

            // Do the stamping animation for first and second star
            GoodStampingAmin();
        }
        if (score >= passScore[level])
        {
            passStar.color = Color.yellow;
            //passStar.GetComponent<Renderer>().material = matPass;
            //passed
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
        finalScore.text = "Score: " + score;
        //Debug.Log("Determination");

    }

    void PassStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));
    }

    void GoodStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp2.DOLocalMoveZ(0, duration).OnComplete(() => starParticles2.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));
    }

    void BestStampingAmin()
    {
        Sequence s = DOTween.Sequence();
        s.Append(StampAnim.stamp1.DOLocalMoveZ(0, duration).OnComplete(() => starParticles1.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp2.DOLocalMoveZ(0, duration).OnComplete(() => starParticles2.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));
        s.AppendInterval(interval);
        s.Append(StampAnim.stamp3.DOLocalMoveZ(0, duration).OnComplete(() => starParticles3.Play()));
        s.Append(StampAnim.cam.DOShakePosition(duration, 1f, 20, 45, false));

    }

}
