
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    InputActions _inputActions;
    public float moveSpeed;
    public float jumpSpeed;
    float _dashCooldown = 0.0f;
    float _isDashing = 0.0f;
    bool _dashed = false;
    bool _airDashed = false;
    float _jumpCooldown = 0.0f;
    float _isJumping = 0.0f;
    bool _jumped = false;
    bool _doubleJumped = false;
    Vector2 _moveInput = new Vector2(0.0f,0.0f);

    float _isSprinting = 0.0f;

    void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Default.Movement.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _inputActions.Default.Movement.canceled += ctx => _moveInput = ctx.ReadValue<Vector2>();

    }


    // Update is called once per frame
    void Update()
    {
        //WASD Movement
        Move(_moveInput*Time.deltaTime);

        _jumpCooldown -= Time.deltaTime;
        _dashCooldown -= Time.deltaTime;
       
    }

    void Move(Vector2 _moveInput)
    {
        gameObject.transform.position = gameObject.transform.position +  new Vector3(_moveInput.x,_moveInput.y,0.0f) * moveSpeed;
    }
    void OnEnable()
    {
        _inputActions.Enable();
    }

    void OnDisable()
    {
        _inputActions.Disable();
    }
}
