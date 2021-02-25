using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 3;

    [Header("Camera")]
    [SerializeField] CameraBaseControl cameraControl = default;

    Rigidbody rb;

    void Start()
    {
        //limit target frame and lock Mouse
        Application.targetFrameRate = 60;
        Utility.LockMouse(CursorLockMode.Locked);

        //get references
        rb = GetComponent<Rigidbody>();

        //set default camera control
        cameraControl.StartDefault(Camera.main.transform, transform);
    }

    void Update()
    {
        //move and rotate
        Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cameraControl.UpdateCameraPosition();
        cameraControl.UpdateRotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    #region private API

    void Movement(float horizontal, float vertical)
    {
        //get local direction
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = transform.TransformDirection(direction);

        //remove y and normalize
        direction.y = 0;
        direction = direction.normalized;

        //move player
        rb.velocity = direction * speed;
    }


    #endregion
}
