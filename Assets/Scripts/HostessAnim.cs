using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HostessAnim : MonoBehaviour
{
    [Header("Hostess")]
    public bool start;
    public Animator animator_HostessStart;
    public GameObject hostess;
    public GameObject hostessWaypoint;
    private float time = 8;

    private void Start()
    {
        //StartCoroutine(HostessStart());
    }

    private void FixedUpdate()
    {
        if (hostess.transform.position == new Vector3(336, 213))
            StartCoroutine(HostessStart());
    }

    IEnumerator HostessStart() // for hostess animation in start screen
    {
        animator_HostessStart.SetTrigger("Play");
        // this is why you don't move the hostess in the scene
        hostess.transform.DOLocalMoveX(hostessWaypoint.transform.position.x, time).OnComplete(() => hostess.transform.position = new Vector3(336, 213));
        yield return null;
    }

}
