using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform target;
    private Camera cam;
    
    public float smoothSpeed = 0.125f;  //used to make the camera movement speed
    
    void Start()
    {

        cam = GetComponent<Camera>();

    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);
        Vector3 desiredPosition;
        Vector3 smoothedPosition; 
        
        if (viewPos.x > 0.7f)
        {
            //move camera
            //Debug.Log("too close");
            
            desiredPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
            
            this.transform.position = (smoothedPosition);
        }

        if (viewPos.x < 0.3f)
        {
            //move camera
            //Debug.Log("too close the other way");
            
            desiredPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
            
            this.transform.position = (smoothedPosition);
        }
    }
}
