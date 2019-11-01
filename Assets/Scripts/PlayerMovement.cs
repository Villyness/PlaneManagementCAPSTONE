using System.Collections;
using System.Collections.Generic;
//using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : PlayerManager
{
    public NavMeshAgent agent;

    public Camera cam;
    public Vector3 targetPos;
    public GameObject target;

    public bool moving = false;
    public Vector3 currentPos;
    public Vector3 oldPos;

    public Transform HoldPos;
    public GameObject HoldFrame;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        NeutralState();
        if (FindObjectOfType<LevelManager>())
            FindObjectOfType<LevelManager>().LevelEnded += NeutralState;
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
                    //Debug.Log("Hello");

                    //if distance is too far, you've hit a roadblock
                    if (target.GetComponent<InteractCustomer>())
                    {
                        if (dist < target.GetComponent<InteractCustomer>().distReq)
                        {
                            target.GetComponent<InteractCustomer>().Interact(this.gameObject);

                            //removes item from players hand, so long as that item isnt a mop
                            if (holding != "Mop") DestoryHolding(); 
                        }
                    }

                    if (target.GetComponent<InteractItems>())
                    {
                        if(handsFull == true)
                            Destroy(HoldFrame.transform.GetChild(0).gameObject);
                        
                        target.GetComponent<InteractItems>().Interact(gameObject);
                        //Debug.Log("link");
                    }
                }
                
                currentPos = new Vector3(0, 0, 0);
                oldPos = new Vector3(0, 0, 0);
                //NeutralState();
            }
            PlayAnimation();
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

                if (hit.collider.GetComponent<InteractItems>() || hit.collider.GetComponent<InteractCustomer>())
                {
                    target = hit.collider.gameObject;
                    //Debug.Log(target);
                }
                else target = null;
            }

            LookAtPoint(hit.point);
            
            //Debug.Log(hit.collider.gameObject.tag);

        }

    }

    public void PlayAnimation()
    {
        StartCoroutine(OnPlay());
    }

    public IEnumerator OnPlay()
    {
        if(currentPos!= oldPos)
        {
            //GetComponentInChildren<Animator>().SetBool("isWalking", true);
        }
        else if(currentPos == oldPos)
        {
            //GetComponentInChildren<Animator>().SetBool("isWalking", false);
        }
        yield return null;
    }

    public void LookAtPoint(Vector3 point)
    {
        Vector3 pointClicked = new Vector3(point.x, GetComponent<Transform>().position.y, point.z);
        GetComponent<Transform>().LookAt(pointClicked);
    }

    public void NeutralState()
    {
        currentPos = new Vector3(0, 0, 0);
        oldPos = new Vector3(0, 0, 0);
        agent.destination = GetComponent<Transform>().position;
        //moving = false;
    }
    
    public void DestoryHolding()
    {
        handsFull = false;
        holding = null;
        Destroy(HoldFrame.transform.GetChild(0).gameObject);
    }

}
