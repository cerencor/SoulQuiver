using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeIdleState : EnemySlimeGroundedState
{
    public EnemySlimeIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySlime enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(0, 0);
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

    }
}
