using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    /// <summary>
    /// NEEDS TO
    /// - register mouse click and locate mouse click -tick-
    /// - move to where the mouse was clicked -tick-
    /// - do whatever the interaction is -tick-
    /// - stop if hits obsetcale -tick, altho could be more polished-
    /// </summary>

    public NavMeshAgent agent;

    public Camera cam;
    public Vector3 targetPos;
    public GameObject target;

    public bool moving = false;
    public Vector3 currentPos;
    public Vector3 oldPos;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        currentPos = new Vector3(0,0,0);
        oldPos = new Vector3(0,0,0);
    }
    
    void Update()
    {

        if (moving == true)
        {
            oldPos = currentPos;
            currentPos = this.transform.position;
            
            if (currentPos == oldPos)
            {
                moving = false;
                //agent.isStopped = true;
                
                //else, check tag
                if (target != null)
                {
                    //check distance from target
                    float dist = Vector3.Distance(this.transform.position, targetPos);
                    Debug.Log(dist);
                    
                    //if distance is too far, you've hit a roadblock
                    if (dist < target.GetComponent<InteractManger>().distReq)
                    {
                        Debug.Log("Close enough, run script");
                        //run interact script - which will be a reference to the InteractManager which then sends it to the objects actually interact script by finding component
                    }

                    target = null;
                }

                oldPos = new Vector3(0,0,0);
                currentPos = new Vector3(0,0,0);
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.Mouse0)) /*&& (moving == false)*/)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //agent.isStopped = false;
                targetPos = hit.point;
                agent.destination = targetPos;
                moving = true;

                if ((hit.collider.gameObject.tag == "interactive") || (hit.collider.gameObject.tag == "customer"))
                    target = hit.collider.gameObject;
                else target = null;

                //Debug.Log(hit.collider.gameObject.tag);

            }

        }
    }
}
