using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StampingAnim : MonoBehaviour
{
    public Transform stamp;
    //public Transform stamp2;
    //public Transform stamp3;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        //stamp.DOLocalMoveZ(stamp.transform.position.z - stamp.transform.position.z, .7f).OnComplete(() => cam.DOShakePosition(1, .1f, 10, 45, false));

        // if score >= some number, move stamp2
        // if score >= some number, move stamp3
    }
}
