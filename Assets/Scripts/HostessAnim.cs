using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HostessAnim : MonoBehaviour
{
    [Header("Hostess")]
    public Animator animator_HostessStart;
    public GameObject hostess;
    public GameObject hostessWaypoint;
    private float time = 8;

    private void Update()
    {
        // creates an animation loop
        if (hostess.transform.position == new Vector3(336, 213))
            HostessStart();
    }

    private void HostessStart() // for hostess animation in start screen
    {
        animator_HostessStart.SetTrigger("Play");
        hostess.transform.DOLocalMoveX(hostessWaypoint.transform.position.x, time).OnComplete(() => hostess.transform.position = new Vector3(336, 213)); // this is why you don't move the hostess in the scene
    }

}
