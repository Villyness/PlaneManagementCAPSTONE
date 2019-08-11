using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractItems : InteractManger
{
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
        Debug.Log("Hello!");
    }
}
