using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) // 생성자
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    // 이게 GroundedState에 있는 이유 = 땅에 있을 때 동작하는 기능이기 때문이다. 공중에 있을 때는 다르게 동작해야함
    protected override void OnMoveCanceled(InputAction.CallbackContext context)
    {
        if(stateMachine.MovementInput == Vector2.zero)
        {
            return;
        }

        stateMachine.ChangeState(stateMachine.IdleState);

        base.OnMoveCanceled(context);
    }

    protected virtual void OnMove()
    {
        stateMachine.ChangeState(stateMachine.WalkState);
    }

}
