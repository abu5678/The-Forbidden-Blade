using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2IdleShadowLordState : ShadowLordGroundedState
{
    public Phase2IdleShadowLordState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, ShadowLord enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //the enemy will stay idle for 1 second
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        //when the 1 second is over the enemy will start moving
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.phase2MoveState);
        }
    }
}
