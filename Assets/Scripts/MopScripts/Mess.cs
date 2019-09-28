using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : InteractItems
{
    public override void Interact(GameObject player)
    {
        // Revamp to include an interactManager of some sort
        if(player.GetComponent<PlayerManager>().holding == "Mop")
            Destroy(this.gameObject);
        //base.Interact(player);
    }
}
