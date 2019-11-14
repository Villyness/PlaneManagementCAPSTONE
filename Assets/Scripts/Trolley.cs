using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;

public class Trolley : InteractItems
{
    public string[] ItemList;
    public int MaxItemCount;

    void Start()
    {
        ItemList = new string[3];
    }
    
    public override void Interact(GameObject player)
    {
        ItemList.Add(player.GetComponent<PlayerManager>().holding);
        base.Interact(player);
    }
}
