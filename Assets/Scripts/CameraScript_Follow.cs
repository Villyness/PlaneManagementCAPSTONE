using System;
using UnityEngine;

public class CameraScript_Follow : MonoBehaviour
{
    [Header("Camera References")]
    public Transform FollowTarget;
    public float smoothSpeed;
    public Vector3 offset;

    [Space]
    [Header("Clamp Points")]
    public float cameraClampMinZ;
    public float cameraClampMaxZ;
    public float cameraClampY;
    public float cameraClampX;
    [SerializeField]private float speed = 2;
    private float currentClampMin;
    private float currentClampMax;
    public Transform ClampPointPos;
    public GameObject ClampArea;
    public float clampOffset; // allow tweaking
    public bool isInKitchen = false;

    [Space]
    [Header("Public References")]
    public static GameObject liveCamera;
    public RectTransform scoreCanvas;
    public ScoreManager sManager;


    void Awake()
    {
        liveCamera = this.gameObject;
    }

    private void Start()
    {
        liveCamera.GetComponent<Camera>().orthographic = true;
    }

    void LateUpdate()
    {
        SmoothCamera();
        OrthoToPersp();
    }

    public void OrthoToPersp()
    {
        if (sManager.ShowScore)
        {
            liveCamera.GetComponent<Camera>().orthographic = false;
        }
    }

    public void SmoothCamera()
    {
        // smooth camera following player
        Vector3 desiredPosition = FollowTarget.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraClampX, cameraClampX),
            Mathf.Clamp(transform.position.z, cameraClampY, cameraClampY),
            Mathf.Clamp(transform.position.z, UpdateClampMin(), UpdateClampMax())
            );
    }

    public float UpdateClampMin()
    {
        if (!isInKitchen)
        {
            return currentClampMin = Mathf.Lerp(currentClampMin, cameraClampMinZ, Time.deltaTime * speed);
        }
        else
        {
            return currentClampMin = Mathf.Lerp(currentClampMin, ClampPointPos.position.z + clampOffset, Time.deltaTime * speed);
        }
    }

    public float UpdateClampMax()
    {
        if (!isInKitchen)
        {
            return currentClampMax = Mathf.Lerp(currentClampMax, ClampPointPos.position.z + clampOffset, Time.deltaTime * speed);
        }
        else
        {
            return currentClampMax = Mathf.Lerp(currentClampMax, cameraClampMaxZ, Time.deltaTime * speed);
        }
    }

}

