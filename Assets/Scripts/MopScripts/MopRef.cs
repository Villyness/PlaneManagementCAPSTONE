using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopRef : MonoBehaviour
{
    public int mopNum;

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
