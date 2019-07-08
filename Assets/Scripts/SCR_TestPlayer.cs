using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TestPlayer : MonoBehaviour
{
    public Collider other;
    public float ForceFactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // HACKY CODE ALERT. IT'S JUST A BUNCH OF MOVEMENT HACK
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("A pressed");

            //(This makes the movement look choppy)
            //transform.Translate(Vector3.left);

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
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something hit");
    }
}
