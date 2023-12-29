using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public SkillsManager Skills {  get; private set; }
    public GameObject sword {  get; private set; }
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
    public PlayerDeadState deadState { get; private set; }
    public PlayerCatchSwordState CatchSwordState { get; private set; }
    public PlayerAimSwordState aimSwordState { get; private set; }


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
        deadState = new PlayerDeadState(stateMachine, this, "Die");
        aimSwordState = new PlayerAimSwordState(stateMachine, this, "AimSword");
        CatchSwordState = new PlayerCatchSwordState(stateMachine, this, "CatchSword");

    }
    #endregion

    protected override void Start()
    {
        base.Start();
        Skills = SkillsManager.instance;
        //sets the player to its starting state which is idle
        stateMachine.Initialise(idleState);
        
    }


    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
        checkForDashInput(); 
    }

    //will be used to check if the player currently has an active sword thrown
    public void assignNewSword(GameObject newSword)
    {
        sword = newSword;
    }
    public void clearTheSword()
    {
        Destroy(sword);
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

        // checks if the dash is available and off cooldown and the user presses left shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && Skills.dash.CanUseSkill())
        {
            dashDir = Input.GetAxisRaw("Horizontal");
            //check to see if the player is not moving then to dash the direction they are facing
            if (dashDir == 0)
                dashDir = facingDir;
            stateMachine.ChangeState(dashState);
        }
    }

}
