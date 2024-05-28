using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIRD PERSON MOVEMENT WITH CHARACTERCONTROLLER
public class TPM_characterController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;

    [SerializeField] private float _gravity = -10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 3f;


    private CharacterController _characterController;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;

    private Vector3 _velocity;
    private bool _isGrounded;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        //Ground Check
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }

        GatherInput();
        NewOrientation();
        Movement();

        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        //BOOST
        if (Input.GetKey(KeyCode.LeftShift) && _isGrounded)
        {
            _speed = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _speed = 5f;
        }
        
        
        //FALLING
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
    private void GatherInput()
    {
        //GET Input
        _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);
    }
    private void NewOrientation()
    {
        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector).normalized;
        _targetDirection.y = 0f;

        //Rotate Object
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void Movement() 
    {
        //Move object along forward
        _characterController.Move(transform.forward * _inputSpeed * _speed * Time.deltaTime);
    }

}
