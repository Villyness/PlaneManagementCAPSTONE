using System;
using UnityEngine;

public class CameraScript_Follow : MonoBehaviour
{
    public Transform FollowTarget;
    public float smoothSpeed;
    public Vector3 offset;

    public float cameraClampMinX;
    public float cameraClampMaxX;
    [SerializeField]private float speed;
    [SerializeField]private float currentClampMin;
    [SerializeField]private float currentClampMax;
    public Transform ClampPointPos;
    public GameObject ClampArea;
    public float clampOffset;
    public bool isInKitchen = false;

    public static GameObject liveCamera;


    void Awake()
    {
        liveCamera = this.gameObject;
    }

    void LateUpdate()
    {
        SmoothCamera();
    }

    public void SmoothCamera()
    {
        // smooth camera following player
        Vector3 desiredPosition = FollowTarget.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, UpdateClampMin(), UpdateClampMax()),
                transform.position.y,
                transform.position.z
                );
    }

    public float UpdateClampMin()
    {
        if (!isInKitchen)
        {
            return currentClampMin = Mathf.Lerp(currentClampMin, cameraClampMinX, Time.deltaTime * speed);
        }
        else
        {
            return currentClampMin = Mathf.Lerp(currentClampMin, ClampPointPos.position.x + clampOffset, Time.deltaTime * speed);
        }
    }

    public float UpdateClampMax()
    {
        if (!isInKitchen)
        {
            return currentClampMax = Mathf.Lerp(currentClampMax, ClampPointPos.position.x + clampOffset, Time.deltaTime * speed);
        }
        else
        {
            return currentClampMax = Mathf.Lerp(currentClampMax, cameraClampMaxX, Time.deltaTime * speed);
        }
    }

}

