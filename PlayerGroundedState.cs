using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.primaryAttackState);
        }

        if (!player.IsGroundDetected()) //if ground is not detected change to air state
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.W) && player.IsGroundDetected()) // w is jump and to jump should be on the ground
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }
}
