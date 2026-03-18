using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f; // Adjusted for MoveDelta
    [SerializeField] float _jumpSpeed = 8.0f;
    [SerializeField] float _gravity = 20.0f;
    [SerializeField] float _sensitivity = 2f;
    
    CharacterController _controller;
    Vector3 _moveDirection = Vector3.zero; // Moved here to track gravity over time
    float _rotationX = 0;
    float _horizontal, _vertical, _mouseX, _mouseY;
    bool _jump;

    // Must be "Start" with a capital S and no parameters
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        // Locks the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
        
        // Use GetButtonDown for jumping to avoid "double jumps"
        if (!_jump) _jump = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        if (_controller.isGrounded)
        {
            // Calculate movement based on current orientation
            Vector3 inputMove = new Vector3(_horizontal, 0, _vertical);
            inputMove = transform.TransformDirection(inputMove);
            
            _moveDirection.x = inputMove.x * _speed;
            _moveDirection.z = inputMove.z * _speed;

            if (_jump)
            {
                _moveDirection.y = _jumpSpeed;
                _jump = false; 
            }
        }

        // Apply gravity constantly
        _moveDirection.y -= _gravity * Time.fixedDeltaTime;

        // 1. Rotate BODY Left/Right (Y Axis)
        transform.Rotate(0, _mouseX * _sensitivity, 0);

        // 2. Rotate CAMERA Up/Down (X Axis) 
        // This assumes your camera is a child of the player
        _rotationX -= _mouseY * _sensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f); // Prevents flipping upside down
        Camera.main.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);

        // Move the controller
        _controller.Move(_moveDirection * Time.fixedDeltaTime);
    }
}
