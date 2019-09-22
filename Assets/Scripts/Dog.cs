using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : InteractCustomer
{
    public override void Start()
    {
        full = 120;
        waitFull = 5;
        needRate = 5;
        base.Start();
    }
}
