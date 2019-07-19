using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TestPassenger : MonoBehaviour
{
    public SCR_InteractableItem currentNeed;
    // Start is called before the first frame update
    void Start()
    {
        currentNeed = new SCR_InteractableItem();
        currentNeed.Name = "Apple";
        Debug.Log(currentNeed.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
