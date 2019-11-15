using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMop : InteractItems
{
    public GameObject myMop;
    public GameObject mopPre; //mop prefab
    public bool hasMop;
    public Vector3 mopSpawn;
    
    void Start()
    {
        mopSpawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        myMop = Instantiate(mopPre, mopSpawn, Quaternion.identity);
        hasMop = true;
        ObjectToSpawn = mopPre;
        ObjectName = "Mop";
    }

    public override void Interact(GameObject player)
    {
        if (hasMop)
        {
            if (!player.GetComponent<PlayerMovement>().handsFull)
            {
                player.GetComponent<PlayerMovement>().holding = "mop";
                base.Interact(player);
                Destroy(myMop);
                hasMop = false;
            }
        }
        else
        {
            player.GetComponent<PlayerMovement>().DestoryHolding();
            //spawn a mop above the area
            Instantiate(mopPre, mopSpawn, Quaternion.identity);
        }
        
    }
    
}
