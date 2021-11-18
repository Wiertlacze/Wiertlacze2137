using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsDigging = Animator.StringToHash("IsDigging");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int IsDrillDown = Animator.StringToHash("IsDrillDown");
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    private static readonly int SpeedPercent = Animator.StringToHash("SpeedPercent");

    private Animator _animator;
    private PlayerMovement _playerMovement;

    [SerializeField] private Animator tracksAnimator;

    private void Awake()
    {
        _animator ??= GetComponent<Animator>();
        _playerMovement ??= GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        SetIsDigging();
        SetIsGrounded();
        SetIsFalling();
        SetIsDrillDown();

        if (tracksAnimator == null)
        {
            return;
        }

        SetTracksMoving();
    }

    private void SetIsDigging()
    {
        var isDigging = Input.GetKey(KeyCode.Space);
        _animator.SetBool(IsDigging, isDigging);
    }

    private void SetIsGrounded()
    {
        var isGrounded = _playerMovement.IsGrounded();
        _animator.SetBool(IsGrounded, isGrounded);
    }

    private void SetIsFalling()
    {
        var isFalling = !Input.GetKey(KeyCode.W);
        _animator.SetBool(IsFalling, isFalling);
    }

    private void SetIsDrillDown()
    {
        var isDrillDown = Input.GetKey(KeyCode.S);
        _animator.SetBool(IsDrillDown, isDrillDown);
    }

    private void SetTracksMoving()
    {
        var speedPercent = _playerMovement.IsGrounded() ? _playerMovement.SpeedPercent() : 0.0f;
        tracksAnimator.SetFloat(SpeedPercent, speedPercent);
    }
}