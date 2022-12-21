using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    Vector2 turn = new Vector2(0, 0);
    Vector3 deltaMove;
    [SerializeField] float sensitivity = 0.5f;
    [SerializeField] GameObject mover;
    [SerializeField] float speed = 1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        turn.y = Mathf.Clamp(turn.y, -10f, 10f);


        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}
