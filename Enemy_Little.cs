using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Little : Enemy
{
    #region States

    public Enemy_LittleIdleState idleState { get; private set; }
    public Enemy_LittleMoveState moveState { get; private set; }
    public Enemy_LittleBattleState battleState { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();

       

        idleState = new Enemy_LittleIdleState(this, stateMachine,"Idle" , this);
        moveState = new Enemy_LittleMoveState(this, stateMachine,"Move" , this);
        battleState = new Enemy_LittleBattleState(this, stateMachine, "Move", this);
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
