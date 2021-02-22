using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCameraPosition = target.position + _offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCameraPosition,
            smoothing * Time.deltaTime);
    }
}
