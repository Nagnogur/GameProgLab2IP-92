using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] float positionSpeed = 0.02f;
    [SerializeField] float rotationSpeed = 0.01f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, positionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraTarget.rotation, rotationSpeed);
    }
}
