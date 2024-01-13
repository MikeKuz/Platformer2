using System;
//using System.Diagnostics;
using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;

    public BootstrapState(GameStateMachine stateMachine)
    {
        Debug.Log("Запущен конструктор BootstrapState");
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        RegisterServices();
    }

    private void RegisterServices()
    {
        Game.InputService = RegisterInputService();

    }

    public void Exit()
    {
        
    }

    private static IInputService RegisterInputService()
    {
        if (Application.isEditor)
        {
            return new StandaloneInputService();
        }
        else
        {
            return new MobileInputService();
        }
    }

}