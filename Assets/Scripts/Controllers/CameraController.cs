using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Makes the camera follow the player */

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    public float zoomSpeed = 4f;
    public float maxZoom = 15f;
    public float minZoom = 5f;

    public float pitch = 2f; 

    public float currentZoom = 10f;

    public float yawSpeed = 100f;
    public float currentYaw = 0f;


    void Update()
    {
        currentZoom -= Input.GetAxisRaw("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxisRaw("Horizontal") * yawSpeed * Time.deltaTime;

    }


    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

}
