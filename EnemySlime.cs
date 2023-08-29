using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : Enemy
{
    #region States

    public EnemySlimeIdleState idleState { get; private set; }
    public EnemySlimeMoveState moveState { get; private set; }
    public EnemySlimeBattleState battleState { get; private set; }
    public EnemySlimeAttackState attackState { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();


        idleState = new EnemySlimeIdleState(this, stateMachine, "Idle", this);
        moveState = new EnemySlimeMoveState(this, stateMachine, "Move", this);
        battleState = new EnemySlimeBattleState(this, stateMachine, "Move", this);
        attackState = new EnemySlimeAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();
        
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
