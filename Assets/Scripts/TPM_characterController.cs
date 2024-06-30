using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using UnityEditor.Callbacks;
using Unity.VisualScripting;
using System.Diagnostics;


// THIRD PERSON MOVEMENT WITH CHARACTERCONTROLLER
public class TPM_characterController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _rotationSpeed = 3f;

    [SerializeField] private float _gravity = -10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    //[SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private SceneState playerData;
    [SerializeField] private Animator _animator;
    //[SerializeField] NPCConversation _npcconversation;

    private CharacterController _characterController;
    private Vector3 _inputVector;
    public float _inputSpeed;
    private Vector3 _targetDirection;

    private Vector3 _velocity;
    private bool _isGrounded;
    private string actualScene;
    private EventInstance playerFootsteps;

    void Awake()
    {
        actualScene = SceneManager.GetActiveScene().name;
    }
    
    private void StartSound()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.playerFootsteps);

    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if (playerData.lastPosition_AI != Vector3.zero && actualScene == "Ambiente iniziale") {
            _characterController.enabled = false;
            transform.position = playerData.lastPosition_AI;
            _characterController.enabled = true; 
        }
        if (playerData.lastPosition_CorridoioM != Vector3.zero && actualScene == "Corridoio_M") {
            _characterController.enabled = false;
            transform.position = playerData.lastPosition_CorridoioM;
            _characterController.enabled = true; 
        }
        
        StartSound();
    }

    
    void Update()
    {
        UpdateAnimation();
        UpdateSound();
        if(playerData.blockMovementPlayer)
        {
            _inputSpeed = 0;
            return;
        }

        //Ground Check 
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = -2f;
        }
        
        GatherInput();
        NewOrientation();
        Movement();
        UpdateLastPosition();
       

 
        
        //BOOST
        if (Input.GetKey(KeyCode.LeftShift) && _isGrounded)
        {
            _animator.SetBool("Run", true);
            _speed = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _animator.SetBool("Run", false);
            _speed = 4f;
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
    private void UpdateAnimation()
    {
        _animator.SetFloat("Speed", _inputSpeed);

    }

    private void UpdateLastPosition()
    {
        if (actualScene == "Ambiente iniziale")
            playerData.lastPosition_AI = transform.position;
        if (actualScene == "Corridoio_M")
            playerData.lastPosition_CorridoioM = transform.position;
    }

    private void UpdateSound()
    {
        if (_inputSpeed > 0f && _isGrounded)
        {
            PLAYBACK_STATE playbackState;
            playerFootsteps.getPlaybackState(out playbackState);

            int terrainType = DetectTerrain();
            playerFootsteps.setParameterByName("Terrain", (int)terrainType);
            
            
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start();
            }

        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
        
    }

    private int DetectTerrain()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2.5f, _groundMask))
        {
            if (hit.collider != null)
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null && renderer.sharedMaterial != null)
                {
                    UnityEngine.Debug.Log("Terreno rilevato: " + renderer.sharedMaterial.name);
                    if (renderer.sharedMaterial.name == "Pavimento Cortile")
                    {
                        return 0;
                    }
                    else if (renderer.sharedMaterial.name == "Prato")
                    {
                        return 1;
                    }

                }
            }
        }
        return 0;

    }
    
}
