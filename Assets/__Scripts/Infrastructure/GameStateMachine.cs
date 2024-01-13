using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    private readonly Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine()
    {
        Debug.Log("Запущен конструктор GameStateMachine");
        _states = new Dictionary<Type, IState>
        {
            [typeof(BootstrapState)] = new BootstrapState(this)
        };
    }

    public void Enter<TState>() where TState : IState
    {
        _activeState?.Exit();
        IState state = _states[typeof(TState)];
        _activeState = state;
        state.Enter();
    }
}
