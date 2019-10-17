using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    // *You tell the person reading this that this is the script for the seats in the level
    // *You also mention that if they wish to contact you about this, that they should @ you in the discord
    // *You then state nonchalantly that writing comments like these is one of the few ways you keep yourself sane.
    
    // [ACT] -> Set Up Variables
    public bool isOccupied;
    public int[] seatPos;

    public Transform spawnPos;
    
    void Start()
    {
        // *You assign a value to the 'spawnPos' variable
        spawnPos = GetComponentInChildren<Transform>();
        //Debug.Log(spawnPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
