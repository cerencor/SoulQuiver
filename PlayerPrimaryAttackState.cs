using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 1;

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if(comboCounter > 1 || Time.time >= lastTimeAttacked + comboWindow)//if last attack is played or spend one second return to player attack 1
        {
            comboCounter = 0;
        }

        player.anim.SetInteger("ComboCounter", comboCounter);//ComboCounter is equal to comboCounter



        float attackDir = player.facingDir; //choose attack direction for switching between enemies left and right

        if(xInput != 0)
            attackDir = xInput;


        player.SetVelocity(player.attackMovement[comboCounter] * attackDir, rb.velocity.y); ////////////////////////???????????????????????????????????????????

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", .15f); // for after exiting, not going into move state (the program gets into move state for a couple of miliseconds and that makes the player move after atacking for a little bit)

        comboCounter++;
        lastTimeAttacked = Time.time; //set last time attacked
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0) //at the time of attack, stop movement
        {
            player.ZeroVelocity();
        }
        if (triggerCalled)//if stop animation trigger is called return to idle state
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
