using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    
    private float Speed = 5.0f;
    private Vector3 PreviousPosition;
    
    [SerializeField]private Camera Cam;

    void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            this.transform.RotateAround(Target.transform.position, Vector3.up, Input.GetAxis("Mouse X")* Speed);
            this.transform.RotateAround(Target.transform.position, Vector3.up, -Input.GetAxis("Mouse Y")* Speed);
        }
    }

    private void Update()
    {
        RotateCamera();
    }
}
