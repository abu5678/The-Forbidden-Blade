using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region movement
    public float moveSpeed = 8f;
    public float jumpForce;

    [SerializeField] private float dashCooldown;
    private float dashTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set;}
    #endregion

    public int facingDir { get; private set; } = 1;
    public bool facingRight = true;

    #region collision checks
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    #endregion

    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }
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
    #endregion

    //initialises variables before game starts
    public void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine,this,"Idle");
        moveState = new PlayerMoveState(stateMachine,this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
        wallSlideState = new PlayerWallSlideState(stateMachine, this, "WallSlide");
        wallJumpState = new PlayerWallJumpState(stateMachine, this, "Jump");

    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(); 
        
        //sets the player to its starting state which is idle
        stateMachine.Initialise(idleState);
        
    }


    private void Update()
    {
        stateMachine.currentState.Update();
        checkForDashInput(); 
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
    //makes it so that the player can move left,right,up and down
    public void setVelocity(float xVelocity,float yVelocity)
    {
        rigidbody2D.velocity = new Vector2 (xVelocity,yVelocity);
        FlipController(xVelocity);
    }

    //check if the player is on the ground
    public bool IsGroundDetected()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    //checks to see if the player is hitting a wall
    public bool isWallDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        //creates a line to be used to check collisions with the floor
        Gizmos.DrawLine(groundCheck.position,new Vector2(groundCheck.position.x,groundCheck.position.y - groundCheckDistance));
        //creates a line to be used to check collisions with walls
        Gizmos.DrawLine(wallCheck.position,new Vector2(wallCheck.position.x + wallCheckDistance,wallCheck.position.y));
    }

    public void FlipPlayer()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipController(float x)
    {
        if(facingRight && x < 0)
        {
            FlipPlayer();
        }
        else if (!facingRight && x > 0)
        {
            FlipPlayer();
        }
    }
}
