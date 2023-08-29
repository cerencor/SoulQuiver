using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimeBattleState : EnemyState
{   
    private Transform player;
    private EnemySlime enemy;
    private int moveDir;
    public EnemySlimeBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySlime enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected())
        {

            stateTimer = enemy.battleTime;
            Debug.Log("State Timer: " + stateTimer);

            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.attackState);
                    //enemy.ZeroVelocity();
                    //return;
                }
            }
            else
            {
                if (stateTimer < 0)
                {
            Debug.Log("State Timer2: " + stateTimer);
                    stateMachine.ChangeState(enemy.idleState);

                }
            }
        }

        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked= Time.time;
            return true;
        }

        return false;
    }

}
