using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : InteractCustomer
{
    public override void Start()
    {
        full = 230;
        waitFull = 80;
        needRate = 2;
        base.Start();
    }
}
