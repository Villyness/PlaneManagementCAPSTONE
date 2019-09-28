using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mop : InteractItems
{

    public override void Interact(GameObject player)
    {
        Debug.Log("Hello");
        base.Interact(player);
        //Destroy(this.gameObject);
    }
}
