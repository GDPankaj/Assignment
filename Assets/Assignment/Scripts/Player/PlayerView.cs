using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    float joystickHorizontalInput;
    float joystickVerticalInput;

    float keyboardHorizontalInput;
    float keyboardVerticalInput;

    float horizontalMovement;
    float verticalMovement;

    bool disableMovement = false;

    [SerializeField] Transform _cameraFollow;
    [SerializeField] float _playerSpeed;
    [SerializeField] FixedJoystick _joyStick;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        GameEvents.Instance.AllShapesCollected.AddListener(DisableMovement);
    }

    private void OnDisable()
    {
        GameEvents.Instance.AllShapesCollected.RemoveListener(DisableMovement);
    }
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        playerController = new PlayerController(new PlayerModel(_playerSpeed), this);
        disableMovement = false;
    }

    private void Update()
    {
        if (!disableMovement) 
        {
            keyboardHorizontalInput = Input.GetAxisRaw("Horizontal");
            keyboardVerticalInput = Input.GetAxisRaw("Vertical");
            joystickHorizontalInput = _joyStick.Horizontal;
            joystickVerticalInput = _joyStick.Vertical;
            
            horizontalMovement = Mathf.Abs(joystickHorizontalInput) > Mathf.Abs(keyboardHorizontalInput) ? joystickHorizontalInput : keyboardHorizontalInput;
            verticalMovement = Mathf.Abs(joystickVerticalInput) > Mathf.Abs(keyboardVerticalInput) ? joystickVerticalInput : keyboardVerticalInput; 
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Debug.Log(_cameraFollow.rotation.eulerAngles);
        playerController.HandleMovement(horizontalMovement, 0f, verticalMovement, _cameraFollow.rotation.eulerAngles.y);
    }

    public void SetPlayerController(PlayerController _playerController)
    {
        this.playerController = _playerController;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.Collected(other);
    }

    private void DisableMovement()
    {
        disableMovement = true;
        horizontalMovement = verticalMovement = 0f;
    }
}