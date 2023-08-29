using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LittleBattleState : EnemyState
{
    private Transform player;
    Enemy_Little enemy;
    private int moveDir;
    public Enemy_LittleBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Little enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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

   
}
