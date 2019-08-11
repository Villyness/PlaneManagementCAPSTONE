using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractItems : InteractManger
{
    //public void 
    void Start()
    {
        interClass = 0;
        FindObjectOfType<LevelManager>().Interacted += CallFunction;
    }

    public void CallFunction(GameObject something)
    {
        Interact(something);
    }

    public override void Interact(GameObject player)
    {
        //Debug.Log("Hello!");
        player.GetComponent<PlayerMovement>().handsFull = true;
        player.GetComponent<PlayerMovement>().holding = "apple";
        //Instantiate()
    }
}
