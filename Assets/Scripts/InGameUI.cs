using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //timerText = GetComponentInChildren<Text>();
        /*if (FindObjectOfType<LevelManager>())
        {
            //int test = (int)(FindObjectOfType<LevelManager>().timer);
            //string testStr = test.ToString();
            //Debug.Log(test);
            //timerText.text = (FindObjectOfType<LevelManager>().timer).ToString();
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = (FindObjectOfType<LevelManager>().timer).ToString();
        scoreText.text = FindObjectOfType<ScoreManager>().score.ToString();
    }
}
