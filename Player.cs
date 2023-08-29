using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack details")]
    public float[] attackMovement;
    public bool isBusy { get; private set; }

    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    
   

    


    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }


    #endregion

    protected override void Awake()
    {   
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");

        moveState = new PlayerMoveState(this, stateMachine, "Move");

        jumpState = new PlayerJumpState(this, stateMachine, "Jump");

        airState = new PlayerAirState(this, stateMachine, "Jump");

        dashState = new PlayerDashState(this, stateMachine, "Dash");

        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");

        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");

        primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");

    }

    protected override void Start() 
    {
        base.Start();

        stateMachine.Initialize(idleState); //starts off with idle state
    }

    protected override void Update()
    {   
        base.Update();
        stateMachine.currentState.Update();

        CheckForDashInput();

    }

    public IEnumerator BusyFor(float _seconds)
    {   
        isBusy= true;

        yield return new WaitForSeconds(_seconds); //waits for a couple of seconds

        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();//animation trigger for makin trigger = true

    private void CheckForDashInput()
    {
        if (IsWallDetected()) //player cant dash when on wall or towards wall
        {
            return;
        }

        dashUsageTimer -= Time.deltaTime; // for dash cooldown


        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown; // for dash cooldown
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0) //if there is no input dash anyway to facing dir
                dashDir = facingDir;


            stateMachine.ChangeState(dashState);
        }
    }


}
