using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target; // The player or object the camera will follow
    public Vector3 offset; // Offset from the target position


    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not set for CameraControll.");
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position
            Vector3 desiredPosition = target.position + offset;
            transform.position = desiredPosition;
            // Rotate the camera to look at the target
            transform.LookAt(target);
        }
    }

}
