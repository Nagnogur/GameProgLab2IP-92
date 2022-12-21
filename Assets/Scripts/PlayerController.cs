using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] KeyCode keyUp;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyDown;
    [SerializeField] KeyCode keyRight;

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float Gravity = 1f;

    private Rigidbody rb;
    private CharacterController _controller;

    Vector3 deltaMove;
    Vector3 _velocity;

    public bool _isGrounded = true;
    [SerializeField] Transform _groundChecker;

    [SerializeField] float GroundDistance = 0.2f;
    [SerializeField] LayerMask Ground;
    [SerializeField] float JumpHeight = 2f;

    [Header("Bonuses //DEBUG")]
    [SerializeField] int pickedUpNum = 0;
    void Start() 
    {
        //rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Debug.Log("jump");
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        _velocity.y += Gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

    }

    void FixedUpdate()
    {
        Vector3 moveWithRotation = transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical");

        deltaMove = moveWithRotation * moveSpeed * Time.deltaTime;

        //transform.Translate(deltaMove);
        _controller.Move(deltaMove);
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Bonus")
        {
            Destroy(collider.gameObject);
            this.pickedUpNum++;
        }
    }
}
