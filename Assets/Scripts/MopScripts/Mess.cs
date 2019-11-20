using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mess : InteractItems
{
    public LevelManager levelManager;
    private SpriteRenderer splash;

    private void Start()
    {
        splash = this.GetComponentInChildren<SpriteRenderer>();
        splash.enabled = false;
    }

    private void Update()
    {
        // spawn mess based on level time percentage
        if (levelManager.timePercentage > 50)
            splash.enabled = true;
    }

    public override void Interact(GameObject player)
    {
        // Revamp to include an interactManager of some sort
        if(player.GetComponent<PlayerManager>().holding == "Mop")
            Destroy(this.gameObject);
        //base.Interact(player);
    }
}
