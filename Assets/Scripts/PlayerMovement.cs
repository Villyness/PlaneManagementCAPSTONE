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
    public Vector3 targetPos;

    public bool moving = false;
    public GameObject target;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
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

        if (moving == true)
        {
            if (this.transform.position == agent.destination)
            {
                moving = false;
                //check tag
                if (target != null)
                {
                    //run interactive/customer script
                    target = null;
                }
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (moving == false))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point;
                agent.destination = targetPos;
                moving = true;

                if ((hit.GameObject.tag == "interactive") || (hit.GameObject.tag == "customer"))
                    target = hit.GameObject;
                else target = null;

                Debug.Log(hit.GameObject.tag);

            }

        }
    }
}
