using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SCR_TestPassenger : MonoBehaviour
{
    #region PassengerNeeds
    //public SCR_InteractableItem currentNeed;
    public string CurrentNeed;
    public string[] ListOfNeeds;
    #endregion

    public event Action Interacted;

    // Update is called once per frame
    void Update()
    {
        #region PassengerNeedsChange
        /*if (Input.GetKeyDown(KeyCode.KeypadEnter))
            CurrentNeed = ListOfNeeds[Random.Range(0, 3)];
        //print(ListOfNeeds[Random.Range(0, 3)])*/
        #endregion
    }

    public void OnMouseDown()
    {
        if (Interacted != null)
            Interacted();
        //Debug.Log("Clicked");
    }
}
