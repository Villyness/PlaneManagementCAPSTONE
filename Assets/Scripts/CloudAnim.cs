using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudAnim : MonoBehaviour
{
    public Transform cloud;
    public Transform cloudPos;
    public Transform cloudWaypoint;
    private float time = 8;

    private void Start()
    {
        cloud.position = cloudPos.position;
    }
    private void Update()
    {
        // creates an animation loop
        if (cloud.position == cloudPos.position)
            CloudAnimation();
    }

    private void CloudAnimation() // for hostess animation in start screen
    {
        cloud.DOLocalMoveZ(cloudWaypoint.position.x, time).OnComplete(() => cloud.position = cloudPos.position); // this is why you don't move the hostess in the scene
    }
}
