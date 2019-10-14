using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action LevelEnded;
    public event Action Pause;
    public float timer;
    public float LevelTimer;

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
        
        foreach (Seat seat in FindObjectsOfType<Seat>())
        {
            //if (seat.isOccupied == true)
            listOfSeats.Add(seat);
                //Debug.Log("Occupied!");
        }
        Debug.Log(listOfSeats.Count);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= LevelTimer)
        {
            if (LevelEnded != null)
                LevelEnded();

            timer = 0;
        }
        
        if(Input.GetKeyDown(KeyCode.Z))
            if (Pause != null)
                Pause();
    }
}
