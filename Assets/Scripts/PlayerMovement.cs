using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    /// <summary>
    /// NEEDS TO
    /// - register mouse click and locate mouse click
    /// - move to where the mouse was clicked
    /// - do whatever the interaction is
    /// - stop if hits obsetcale
    /// </summary>
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetTouch(0)))
        {
            Touch touch = Input.GetTouch(0);
            
            case (touch.phrase)
            {
                case TouchPhase.Began:
                    //move
                break;
            }

            //find mouse position

        }
    }
}
