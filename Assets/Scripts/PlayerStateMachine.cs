using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{ 
    //value is public to get but private to set
    public PlayerState currentState {  get; private set; } 

    public void Initialise (PlayerState _startState)
    {  
        currentState = _startState;
        currentState.Enter();
    }
    public void ChangeState (PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
