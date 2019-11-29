using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : InteractCustomer
{
    // Could probably put some literals here for the designers
    
    public override void Start()
    {
        full = 150;
        waitFull = 60;
        needRate = 3;
        base.Start();
    }
    
}
