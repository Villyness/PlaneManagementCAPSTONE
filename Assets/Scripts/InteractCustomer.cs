using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InteractCustomer : MonoBehaviour
{
    // This is the script for customers
    // It inherits from the script 'InteractManger' (yes we know it's spelt wrong)
    // Setting up...
    // TODO: Set this various to private [pr]
    public int distReq;
    public bool hasNeed;    //[pr]
    public string need;

    public int timer;    //[pr]
    public int full;    //[pr]

    public int waitFull;
    public int waitTime;

    public Material success;
    public Material fail;

    public Material ownMat;
    
    // V's stuff
    public GameObject spawnPos;
    public GameObject drinkObj;
    public GameObject foodObj;

    public int needRate;
    public int needRatio;

    public int nextNeedDelay;
    public int patienceTimer;

    public virtual void Start()
    {
        //interClass = 1;
        this.GetComponent<Renderer>().material = ownMat;
        
        waitTime = waitFull;
        timer = full;
    }

    public virtual void FixedUpdate()
    {
        if (timer == full)
        {
            if (hasNeed == false)
            {
                int temp = Random.Range(0, 10);

                // revamp this so that it manages its own
                
                if (temp >= needRate)
                {
                    //Debug.Log("has need");
                    hasNeed = true;
                    PickNeed();
                }
            }
        }
        
        timer--;

        if (timer <= 0)
        {
            if (hasNeed == true)
            {
                waitTime -= 1;
                if (waitTime >= 0)
                {
                    //failed
                    hasNeed = false;
                    //FindObjectOfType<ScoreManager>().score -= 1;    // Could probably fire events
                }
            }
            timer = full;
        }
    }


    public void Interact(GameObject player)
    {
        //Debug.Log("Hello");
        if (player.GetComponent<PlayerManager>().handsFull == true)
        {
            if (player.GetComponent<PlayerManager>().holding == need)
            {
                hasNeed = false;
                waitTime = waitFull;
                //FindObjectOfType<ScoreManager>().score += 1;
                this.GetComponent<Renderer>().material = success;
            }

            else
            {   //failed
                hasNeed = false;
                waitTime = waitFull;
                //FindObjectOfType<ScoreManager>().score -= 1;
                this.GetComponent<Renderer>().material = fail;
            }
        }
    }
    
    public void PickNeed()
    {
        int x = Random.Range(0, 10);

        if (x > needRatio)
        {
            need = "drink";
            Instantiate(drinkObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
        }
        else
        {
            need = "food";
            Instantiate(foodObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
        }
                
    }   
}
