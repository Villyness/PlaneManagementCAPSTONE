using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TestPlayer : MonoBehaviour
{
    // Setting up...
    public Collider other;
    public float ForceFactor;
    public Transform HoldPos;
    public bool ItemHeld;

    // Update is called once per frame
    void Update() // HACKY CODE ALERT. IT'S JUST A BUNCH OF MOVEMENT HACK
    {
        #region HackyMovementCode
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * ForceFactor);
        }

        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().AddForce(Vector3.forward * ForceFactor);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().AddForce(Vector3.back * ForceFactor);

        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().AddForce(Vector3.right * ForceFactor);

        // Kinda choppy movement but it's not too important
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D))
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        #endregion
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (other.GetComponent<SCR_Interactable>() && ItemHeld == false)
            {
                other.gameObject.transform.parent = HoldPos;
                ItemHeld = true;
            }
        }
    }
}

/* NOTE: THIS IS STUFF TO BE LEARNED FROM SCRIPT
 
 //(This makes the movement look choppy)
            //transform.Translate(Vector3.left);*/
