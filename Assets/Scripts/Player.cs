using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Animator animator { get; private set; }
    public Rigidbody2D rigidbody2D { get; private set; }


    public PlayerStateMachine stateMachine { get; private set; }
    
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    

    public void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine,this,"Idle");
        moveState = new PlayerMoveState(stateMachine,this, "Move");

    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();  
        //sets the player to its starting state
        stateMachine.Initialise(idleState);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         stateMachine.currentState.Update();
    }

    public void setVelocity(float xVelocity,float yVelocity)
    {
        rigidbody2D.velocity = new Vector2 (xVelocity,yVelocity);
    }
}
