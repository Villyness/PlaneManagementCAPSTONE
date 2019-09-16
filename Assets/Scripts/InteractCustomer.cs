using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InteractCustomer : InteractManger
{
    // This is the script for customers
    // It inherits from the script 'InteractManger' (yes we know it's spelt wrong)
    // Setting up...
    // TODO: Set this various to private [pr]
    public bool hasNeed;    //[pr]
    public string need;

    public int timer;    //[pr]
    public int full;    //[pr]

    public int waitFull;
    public int waitTime;

    public Material success;
    public Material fail;
    
    // V's stuff
    public GameObject spawnPos;
    public GameObject drinkObj;
    public GameObject foodObj;
    
    void Start()
    {
        interClass = 1;
        switch (interType)
        {
            case "cat":
                full = 90;
                waitFull = 2;
                break;
            case "dog":
                full = 120;
                waitFull = 4;
                break;
        }

        waitTime = waitFull;
        timer = full;
    }

    private void FixedUpdate()
    {
        if (timer == full)
        {
            if (hasNeed == false)
            {
                int temp = Random.Range(0, 10);
                switch (interType)
                {
                    case "cat":
                        if (temp >= 7)
                        {
                            //Debug.Log("has need");
                            hasNeed = true;
                            PickNeed();
                        }
                        break;
                    case "dog":
                        if (temp >= 5)
                        {
                            //Debug.Log("has need");
                            hasNeed = true;
                            PickNeed();
                        }
                        break;
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
                    FindObjectOfType<PlayerManager>().score -= 1;
                }
            }
            
            timer = full;
        }
    }


    public override void Interact(GameObject player)
    {
        if (player.GetComponent<PlayerManager>().handsFull == true)
        {
            if (player.GetComponent<PlayerManager>().holding == need)
            {
                hasNeed = false;
                waitTime = waitFull;
                player.GetComponent<PlayerManager>().ScoreIncrease();
                this.GetComponent<Renderer>().material = success;
            }

            else
            {   //failed
                hasNeed = false;
                waitTime = waitFull;
                FindObjectOfType<PlayerManager>().score -= 1;
                this.GetComponent<Renderer>().material = fail;
            }
        }
    }
    
    void PickNeed()
    {
        int x = Random.Range(0, 10);
        
        switch (interType)
        {
            case "cat":
                if (x > 5)
                {
                    need = "drink";
                    Instantiate(drinkObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
                }
                else
                {
                    need = "food";
                    Instantiate(foodObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
                }
                break;
            case "dog":
                if (x > 5)
                {
                    need = "drink";
                    Instantiate(drinkObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
                }
                else
                {
                    need = "food";
                    Instantiate(foodObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
                }
                break;
        }
    }
    
    
}
