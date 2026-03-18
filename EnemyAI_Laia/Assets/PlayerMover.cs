using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private Rigidbody _rb;
    private Vector2 _moveInput;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Se llama desde el Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
        _moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveInput.x, 0f, _moveInput.y);
        _rb.MovePosition(_rb.position + move * speed * Time.fixedDeltaTime);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Attack!");
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
