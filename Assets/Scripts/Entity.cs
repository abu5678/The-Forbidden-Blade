using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//for both players and enemies since they share alot
public class Entity : MonoBehaviour
{
    #region collision checks
    [Header("Collsion Info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    #endregion

    #region Components
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }
    #endregion

    public int facingDir { get; private set; } = 1;
    public bool facingRight = true;


    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {

    }

    #region collision detection
    //check if the character is on the ground
    public virtual bool IsGroundDetected()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    //checks to see if the character is hitting a wall
    public virtual bool isWallDetected()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }
    protected virtual void OnDrawGizmos()
    {
        //creates a line to be used to check collisions with the floor
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        //creates a line to be used to check collisions with walls
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    #endregion

    #region flip character
    public virtual void FlipCharacter()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipController(float x)
    {
        if (facingRight && x < 0)
        {
            FlipCharacter();
        }
        else if (!facingRight && x > 0)
        {
            FlipCharacter();
        }
    }
    #endregion

    #region velocity
    //makes the character stop moving
    public void ZeroVelocity()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
    }
    //makes it so that the character can move left,right,up and down
    public void setVelocity(float xVelocity, float yVelocity)
    {
        rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }
    #endregion
}
