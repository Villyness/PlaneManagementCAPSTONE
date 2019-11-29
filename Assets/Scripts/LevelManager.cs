using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = System.Random;

public class LevelManager : MonoBehaviour
{
    public event Action LevelEnded;
    public event Action Pause;
    //public event Action<int> setDist;
    [Header("Time related")]
    public float timer;
    public int timerInt;
    public float timePercentage;
    public float LevelTimer;
    public GameObject[] passengers;
    public bool end = false;

    [Header("Passengers")]
    private List<Seat> listOfSeats;
    public Vector3 displacementVect;
    public int minPassenger = 5;
    public int maxPassenger = 8;
    public int passengerCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Music progression
        float t = LevelTimer/5;
        InvokeRepeating("GameplayProgress", t, t);

        /*if (Interacted != null)
        {
            Interacted(this.gameObject);
            Debug.Log("Sent");
        }
        else
        {
            Debug.Log("Null!");
        }*/
        listOfSeats = new List<Seat>();

        while (passengerCount < minPassenger)
        {
            foreach (Seat seat in FindObjectsOfType<Seat>())
            {
                // exit spawn loop if we hit max
                if (passengerCount >= maxPassenger) break;
                if (seat.isOccupied) continue;
                //if (seat.isOccupied == true)
                listOfSeats.Add(seat);
                //Debug.Log(seat.GetComponent<Transform>().position + displacementVect);
                if (UnityEngine.Random.Range(1, 10) <= 2) // Whether or not to assign the seat a passenger
                {
                    GameObject passenger = Instantiate(passengers[0], seat.GetComponent<Transform>().position + displacementVect, Quaternion.identity);
                    passengerCount++;
                    seat.isOccupied = true;

                    // Refactor this later on
                    if (seat.seatPos[0] == 1 | seat.seatPos[0] == 4)
                    {
                        passenger.GetComponent<InteractCustomer>().distReq = 5;
                    }
                    else
                    {
                        passenger.GetComponent<InteractCustomer>().distReq = 3;
                    }
                    /*if (setDist != null)
					{
						setDist(seat.seatPos[0]);
					}*/
                    //Debug.Log(seat.seatPos[1]);
                }
                //Debug.Log("Occupied!");
            }

            if (passengerCount >= minPassenger) break;
        }

        //Debug.Log(listOfSeats.Count);

        // Set up level SFX
        // Level end sfx
        AudioManager.instance.win = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Win");
        // Passenger sfx
        AudioManager.instance.drinking = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Drinking");
        AudioManager.instance.eating = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Eating");
        // Hostess sfx
        AudioManager.instance.pourDrink = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PourDrink");
        AudioManager.instance.serveFood = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/ServeFood");
        AudioManager.instance.mopping = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Mopping");
        AudioManager.instance.walking = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Walking");

    }

    // Update is called once per frame
    void Update()
    {
        timePercentage = (timer / LevelTimer) * 100;

        if (!end)
        {
            timer += Time.deltaTime;
            timerInt = (int)timer;
            if (timer > LevelTimer)
            {
                if (LevelEnded != null)
                {
                    LevelEnded();
                    end = true;
                    AudioManager.instance.win.start();
                }

                timer = 0;
            }
        }
    }

    // Music Progression
    void GameplayProgress()
    {
        AudioManager.progression += 1f;
        AudioManager.instance.MusicProgression();
    }

}
