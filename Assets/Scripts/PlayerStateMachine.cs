using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{ 
    public PlayerState currentState {  get; private set; }

    //sets the player to its starting state
    public void Initialise (PlayerState _startState)
    {  
        currentState = _startState;
        currentState.Enter();
    }

    //exits the player from its current state and lets the player enter a new state
    //for example going from idle to moving
    public void ChangeState (PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
