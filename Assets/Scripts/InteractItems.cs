using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Vuforia;

public class InteractItems : MonoBehaviour
{
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
        
        Instantiate(ObjectToSpawn, spawnPos, Quaternion.identity, player.GetComponent<PlayerMovement>().HoldPos);
    }
}
