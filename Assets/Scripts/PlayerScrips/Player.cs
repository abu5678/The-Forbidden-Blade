using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    #region Attacks
    [Header("Attack Info")]
    public Vector2[] attackMovement;
    public float counterAttackDurtaion = 0.2f;
    #endregion

    public bool isBusy {  get; private set; }

    [Header("Move Info")]
    #region movement
    public float moveSpeed = 8f;
    public float jumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashCooldown;
    private float dashTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set;}
    


    #endregion

    #region states
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }


    //initialises variables before game starts
    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine,this,"Idle");
        moveState = new PlayerMoveState(stateMachine,this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
        wallSlideState = new PlayerWallSlideState(stateMachine, this, "WallSlide");
        wallJumpState = new PlayerWallJumpState(stateMachine, this, "Jump");
        primaryAttackState = new PlayerPrimaryAttackState(stateMachine, this, "Attack");
        counterAttackState = new PlayerCounterAttackState(stateMachine, this, "CounterAttack");

    }
    #endregion

    protected override void Start()
    {
        base.Start();

        //sets the player to its starting state which is idle
        stateMachine.Initialise(idleState);
        
    }


    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
        checkForDashInput(); 
    }

    //used to make sure certain actions cannot be done at the same time
    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;

        //after a certain amount of time isBusy will become false
        yield return new WaitForSeconds(seconds);

        isBusy = false;
    }

    //calls animationFinishTrigger to notify that the animation has finished
    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
    private void checkForDashInput()
    {
        //makes it so that the player cannot dash if they are wall sliding
        if (isWallDetected())
            return;

        dashTimer -= Time.deltaTime;
        //dashTimer < 0 checks if the dash is available and off cooldown
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer < 0)
        {
            //resets dash cooldown
            dashTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            //check to see if the player is not moving then to dash the direction they are facing
            if (dashDir == 0)
                dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

}
