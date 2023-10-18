using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBaseState : IState
{
    // �⺻������ ��� state�� StateMachine�� ������
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine playerStateMachine) // ������
    {
        stateMachine = playerStateMachine;
        groundData = stateMachine.Player.Data.GroundedData;
    }

    // �������̵� �ϴ� �뵵 - virtual
    public virtual void Enter() 
    {
        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
        Move();
    }

    //
    protected virtual void AddInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled += OnMoveCanceled;
        input.PlayerActions.Jump.started += OnJumpStarted;
    }

    

    protected virtual void RemoveInputActionsCallbacks()
    {
        PlayerInput input = stateMachine.Player.Input;
        input.PlayerActions.Move.canceled -= OnMoveCanceled;
        input.PlayerActions.Jump.started -= OnJumpStarted;
    }

    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {

    }

    protected virtual void OnMoveCanceled(InputAction.CallbackContext context)
    {

    }

    private void ReadMovementInput()
    {
        stateMachine.MovementInput = stateMachine.Player.Input.PlayerActions.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0;  // ���� ���ϸ� ������ �� 
        right.y = 0;

        forward.Normalize();  // ���� ��ü�� �븻������
        right.Normalize();

        return forward * stateMachine.MovementInput.y + right * stateMachine.MovementInput.x; // �̵��ؾ� �ϴ� ���Ϳ� �Է��� ������ ������ ���ؼ� �̵���
    }
    private void Rotate(Vector3 movementDirection) // ȸ��
    {
        if(movementDirection != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    private void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Player.Controller.Move(
            ((movementDirection * movementSpeed) + stateMachine.Player.ForceReceiver.Movement) * Time.deltaTime

            ); 
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
