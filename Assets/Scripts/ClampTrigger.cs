using System;
using UnityEngine;

public class ClampTrigger : MonoBehaviour
{
    public CameraScript_Follow _camera;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!_camera.isInKitchen)
            {
                _camera.isInKitchen = true;
            }
            else
            {
                _camera.isInKitchen = false;
            }
        }
    }
}
