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
    private Digging _digging; //Dodany odnoœnik do skryptu digging

    [SerializeField] private Animator tracksAnimator;

    private void Awake()
    {
        _animator ??= GetComponent<Animator>();
        _playerMovement ??= GetComponent<PlayerMovement>();
        _digging ??= GetComponent<Digging>(); //aktywacja digging idk
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
        var isDigging = Input.GetKey(KeyCode.Space) || _digging.busy; //Sprawdzanie czy bool "busy" ze skryptu digging jest true ¿eby zachowaæ animacjê wiert³a na dole w trakcie kopania
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
        var isDrillDown = Input.GetKey(KeyCode.S) || _digging.digDown; //Sprawdzanie czy bool "digDown" ze skryptu digging jest true ¿eby zachowaæ pozycjê wiert³a na dole w trakcie kopania
        _animator.SetBool(IsDrillDown, isDrillDown);
    }

    private void SetTracksMoving()
    {
        var speedPercent = _playerMovement.IsGrounded() ? _playerMovement.SpeedPercent() : 0.0f;
        tracksAnimator.SetFloat(SpeedPercent, speedPercent);
    }
}