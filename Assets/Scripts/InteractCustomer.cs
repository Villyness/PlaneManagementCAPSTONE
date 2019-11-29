using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class InteractCustomer : MonoBehaviour
{
    // This is the script for customers
    // It inherits from the script 'InteractManger' (yes we know it's spelt wrong)
    // Setting up...
    // TODO: Set this various to private [pr]
    public int distReq;
    public Seat custSeat;
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

    public event Action<int> PointsAwarded;
    public int pointsMax;
    private int currentPoints;

    public GameObject HeldItem; 
    private Animator anim; 

    public virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AudioManager.instance.eating, transform, GetComponent<Rigidbody>());


        //interClass = 1;
        this.GetComponent<Renderer>().material = ownMat;
        
        //find seat that its sitting on
        custSeat = FindObjectOfType<Seat>();
        //depending on seat number, set distReq
        if (custSeat.seatPos[0] == 1 || custSeat.seatPos[0] == 4) distReq = 7;
        else distReq = 3;
        
        waitTime = waitFull;
        timer = full;
        
        //Remove code after testing
        currentPoints = 100;
        
        
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
            if (hasNeed)
            {
                waitTime -= 1;
                if (waitTime <= 0)
                {
                    //failed
                    hasNeed = false;
                    Destroy(HeldItem);
                    timer = full*2;
                    //despawn need
                    //timer = full;
                    //FindObjectOfType<ScoreManager>().score -= 1;    // Could probably fire events
                }
            }
            else
            {
                timer = full;
            }
        }
    }


    public void Interact(GameObject player)
    {
        //Debug.Log("Hello");
        if (player.GetComponent<PlayerManager>().handsFull == true)
        {
            if (player.GetComponent<PlayerManager>().holding == need)
            {
                hasNeed = false;    //These lines of code can likely be put into their own separate function
                waitTime = waitFull;
                //FindObjectOfType<ScoreManager>().score += 1;
                //this.GetComponent<Renderer>().material = success;
                //Debug.Log(spawnPos.gameObject);
                //Destroy(spawnPos.gameObject);
                if(PointsAwarded != null)
                    PointsAwarded(currentPoints);
                    
                Destroy(HeldItem);
                // trigger eating animation 
                anim.SetTrigger("eat");
                // eating sfx 
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Eating", transform.position);

            }

            if (player.GetComponent<PlayerManager>().holding == "Mop") {} //nothing happens

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
            Destroy(HeldItem);
            HeldItem = Instantiate(drinkObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
        }
        else
        {
            need = "food";
            Destroy(HeldItem);
            HeldItem = Instantiate(foodObj, spawnPos.GetComponent<Transform>().position, Quaternion.identity);
        }
        //currentPoints = pointsMax;
                
    }   
}
