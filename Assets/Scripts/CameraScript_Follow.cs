using System;
using UnityEngine;

public class CameraScript_Follow : MonoBehaviour
{
    public Transform FollowTarget;
    public float smoothSpeed;
    public Vector3 offset;

    public float cameraClampMinX;
    public float cameraClampMaxX;
    public GameObject ClampPoint;
    Collider collider;
    [SerializeField]private bool isInKitchen;
    //private bool isInFuselage;

    public static GameObject liveCamera;


    void Awake()
    {
        liveCamera = this.gameObject;
    }

    private void Start()
    {
        collider = ClampPoint.GetComponent<Collider>();
    }

    private void Update()
    {

        if (FollowTarget.position.x < ClampPoint.transform.position.x)
        {
            isInKitchen = false;
        }
        else
        {
            isInKitchen = true;
        }
    }

    void LateUpdate()
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

    private float UpdateClampMin()
    {
        if (!isInKitchen) return cameraClampMinX;
        else if (isInKitchen) return ClampPoint.transform.position.x;
        return cameraClampMinX;
    }

    private float UpdateClampMax()
    {
        if (!isInKitchen) return ClampPoint.transform.position.x;
        else if (isInKitchen) return cameraClampMaxX;
        return cameraClampMaxX;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, UpdateClampMin(), UpdateClampMax()),
            transform.position.y,
            transform.position.z
                );
    }

}

