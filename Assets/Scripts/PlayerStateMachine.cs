using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }

    public void Initialize(PlayerState _initState)
    {
        currentState = _initState;
        currentState.Enter();
    }
    public void ChangeState(PlayerState _newState)
    {

        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}
