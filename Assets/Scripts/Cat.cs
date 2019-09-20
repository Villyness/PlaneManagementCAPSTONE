using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : InteractCustomer
{
    public override void Start()
    {
        this.GetComponent<Renderer>().material = ownMat;
        /*waitTime = waitFull;
        timer = full;*/
        base.Start();
    }

    public override void FixedUpdate()
    {
        if (timer == full)
        {
            if (hasNeed == false)
            {
                int temp = Random.Range(0, 10);

                // revamp this so that it manages its own
                
                if (temp >= needRate)
                {
                    //Debug.Log("has need");
                    hasNeed = true;
                    PickNeed();
                }
            }
        }
        base.FixedUpdate();
    }
}
