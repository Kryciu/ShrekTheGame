using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float RotationSpeed = 5.0f;
    public float MovingSpeed = 10.0f;
    public Vector3 Offset;

    private bool ShouldFollowPlayer = false;

    void RotateCamera()
    {
        if (!ShouldFollowPlayer)
        {
            if (Input.GetMouseButton(0))
            {
                this.transform.RotateAround(Target.transform.position, Vector3.up, Input.GetAxis("Mouse X")* RotationSpeed);
            }
        }
    }

    void FollowPlayer()
    {
        if (ShouldFollowPlayer)
        {
            Vector3 DesiredPosition = Target.transform.position + Offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, MovingSpeed * Time.deltaTime);
            transform.position = SmoothedPosition;
        }
        transform.LookAt(Target.transform);
    }

    private void LateUpdate()
    {
        FollowPlayer();
        RotateCamera();
    }

    public void IsFollowing()
    {
        ShouldFollowPlayer = !ShouldFollowPlayer;
    }
}
