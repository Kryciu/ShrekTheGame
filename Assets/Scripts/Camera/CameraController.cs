using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1.0f;
    public Vector3 Offset;

    private void LateUpdate()
    {
        Vector3 DesiredPosition = Target.position + Offset;
        Vector3 FinalPosition = Vector3.Lerp(transform.position, DesiredPosition, Speed * Time.deltaTime);
        transform.position = FinalPosition;
        
        transform.LookAt(Target);
    }
}
