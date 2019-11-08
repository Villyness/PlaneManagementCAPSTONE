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
    public float timer;
    public int timerInt;
    public float LevelTimer;
    public GameObject[] passengers;
    public bool end = false;

    private List<Seat> listOfSeats;
    
    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 displacementVect = new Vector3(0, 2, 0.5f);
        foreach (Seat seat in FindObjectsOfType<Seat>())
        {
            //if (seat.isOccupied == true)
            listOfSeats.Add(seat);
            //Debug.Log(seat.GetComponent<Transform>().position + displacementVect);
            if (UnityEngine.Random.Range(1, 10) <= 2)
            {
                GameObject passenger = Instantiate(passengers[0], seat.GetComponent<Transform>().position + displacementVect, Quaternion.identity);

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
        //Debug.Log(listOfSeats.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            timer += Time.deltaTime;
            timerInt = (int) timer;
            if (timer > LevelTimer)
            {
                if (LevelEnded != null)
                {
                    LevelEnded();
                    end = true;
                }

                timer = 0;
            }

            //if (Input.GetKeyDown(KeyCode.Z))
            //    if (Pause != null)
            //        Pause();
        }
    }
}
