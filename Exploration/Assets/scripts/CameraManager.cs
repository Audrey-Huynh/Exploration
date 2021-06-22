using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransform;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float camerafollowSpeed = 0.05f;
    public float cameralookSpeed = 2f;
    public float camerapivSpeed = 2f;
    public Transform cameraPivot;
    public float lookAngle;
    public float pivotAngle;
    public float pivmin = -35;
    public float pivmax = 5;

    private void Awake()
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        inputManager = FindObjectOfType<InputManager>();
    }
    private void FollowTarget()
    {
        Vector3 targetposition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, camerafollowSpeed);
        transform.position = targetposition;
    }

    private void CameraRotation()
    {
        lookAngle = lookAngle + (inputManager.camerax * cameralookSpeed);
        pivotAngle = pivotAngle + (inputManager.cameray * camerapivSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, pivmin, pivmax);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetrotation = Quaternion.Euler(rotation);
        transform.rotation = targetrotation;

        rotation = Vector3.zero;
        rotation.x = -pivotAngle;
        targetrotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetrotation;

    }

    public void HandleAllCamera()
    {
        FollowTarget();
        CameraRotation();
    }
}
