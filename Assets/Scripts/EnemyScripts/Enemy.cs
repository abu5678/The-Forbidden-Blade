using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [Header("Move Info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack Info")]
    public float attackDistance;
    public float attackCooldwon;
    public float lastTimeAttacked;
    public EnemyStateMachine stateMachine {  get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    public virtual RaycastHit2D isPlayerDetected()
    {
        //makes it so that the enemy can detect the player if they are within range and facing the player
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        //will be used for enemy attack range
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir,transform.position.y));
    }
    //used to make an animtation stop
    public virtual void animationFinishTrigger ()
    {
        stateMachine.currentState.animationFinishTrigger();
    }
}
