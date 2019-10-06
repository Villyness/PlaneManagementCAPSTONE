using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : InteractCustomer
{
    // Could probably put some literals here for the designers
    
    public override void Start()
    {
        full = 90;
        waitFull = 2;
        needRate = 5;
        base.Start();
    }
    
}
