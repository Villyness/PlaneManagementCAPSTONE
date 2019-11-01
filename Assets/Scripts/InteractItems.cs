using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Vuforia;

public class InteractItems : MonoBehaviour
{
    // This is the main script for interactable items like perishables/mop
    // Script was mostly done by V, so @ me in the discord if you need to yell at me (#4084)
    // Also go play Oneshot it's a GOOD GAME
    
    public GameObject ObjectToSpawn;
    public string ObjectName;
    
    void Start()
    {
        //interClass = 0;
        //FindObjectOfType<LevelManager>().Interacted += CallFunction;
    }

    /*public void CallFunction(GameObject something)
    {
        Interact(something);
    }*/

    public virtual void Interact(GameObject player)
    {
        //Debug.Log("Hello!");
        player.GetComponent<PlayerMovement>().handsFull = true;
        player.GetComponent<PlayerMovement>().holding = ObjectName;
        
        //shout to Harrison for his help 
        Vector3 spawnPos = player.transform.position + player.GetComponent<PlayerMovement>().HoldPos.localPosition;
        
        Instantiate(ObjectToSpawn, spawnPos, Quaternion.identity, player.GetComponent<PlayerMovement>().HoldPos);    // probably needs to be moved to the Player's script
    }
}
