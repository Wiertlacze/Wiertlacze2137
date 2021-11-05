using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float flyForce = 1.0f;
    public float maxFlyVelocity = 1.0f;
    public float maxHeight = 10.0f;

    private Rigidbody _rigidbody;

    private bool _canMove = true;
    private bool _lookingRight = true;

    private float _fallMultiplier = 2f;

    private void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        if (_canMove)
        {
            HandleSidewaysMovement();
            HandleUpwardsMovement();
        }

        HandleRotation();

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplier - 1.0f) * Time.deltaTime;
        }
    }

    private void HandleSidewaysMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveSideways(-1.0f);
            _lookingRight = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveSideways(1.0f);
            _lookingRight = true;
        }
    }

    private void MoveSideways(float value)
    {
        _rigidbody.velocity = new Vector3(value * movementSpeed, _rigidbody.velocity.y, 0.0f);
    }

    private void HandleUpwardsMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUpwards();
        }
    }

    private void MoveUpwards()
    {
        if (transform.position.y >= maxHeight)
        {
            return;
        }

        var newVelocity = _rigidbody.velocity;
        var force = flyForce;
        if (newVelocity.y < maxFlyVelocity)
        {
            if (newVelocity.y < 0.0f)
            {
                force *= 3.0f;
            }

            newVelocity += Vector3.up * -Physics.gravity.y * force * Time.deltaTime;
        }

        _rigidbody.velocity = newVelocity;
    }

    private void HandleRotation()
    {
        var desiredRotation = Quaternion.LookRotation(_lookingRight ? Vector3.forward : Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 20.0f * Time.deltaTime);
    }
}