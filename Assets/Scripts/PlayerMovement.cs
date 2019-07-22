using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    /// <summary>
    /// NEEDS TO
    /// - register mouse click and locate mouse click -tick-
    /// - move to where the mouse was clicked -tick-
    /// - do whatever the interaction is
    /// - stop if hits obsetcale
    /// </summary>

    public NavMeshAgent agent;

    public Camera cam;
    public Vector3 target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((Input.GetKeyDown(KeyCode.Mouse0)) && (Input.GetTouch(0)))
        {
            Touch touch = Input.GetTouch(0);
            
            case (touch.phrase)
            {
                case TouchPhase.Began:
                
                    
                //move
                break;
            }*/
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                agent.destination = target;
            }

        }
    }
}
