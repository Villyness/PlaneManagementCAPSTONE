using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManger : MonoBehaviour
{
    //for both the customers and the interactable objects, probably made inherited
    
    //tells the player if they're sitting in an isle sit or a window/middle seat, which changes the distance required
    public float distReq;

    //determines what this is
    public int interClass; //0 - object, 1 - customer
    public string interType; //a string reading what it is - ie "cat" or "drink"
    
    //in child script - determine if its being held, if need is met, etc.


    public virtual void Interact()
    {
        //have each script override this with what happens when interacts
    }
    
}
