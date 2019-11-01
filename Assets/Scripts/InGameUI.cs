using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text timerText;
    public Text scoreText;

    public bool levelEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += End;
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelEnded)
        {
            timerText.text = FindObjectOfType<LevelManager>().timerInt.ToString();
            scoreText.text = FindObjectOfType<ScoreManager>().score.ToString();
        }
        
    }

    void End()
    {
        levelEnded = true;
    }
}
