using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StampingAnim : MonoBehaviour
{
    public Transform stamp1;
    public Transform stamp2;
    public Transform stamp3;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        stamp1.DOMoveZ(stamp1.transform.position.z + 300, 1).OnComplete(() => cam.DOShakePosition(1, 20, 20, 90, false));

        // if score >= some number, move stamp2
        // if score >= some number, move stamp3
    }
}
