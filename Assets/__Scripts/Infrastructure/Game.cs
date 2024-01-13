using UnityEngine;

public class Game
{
    public static IInputService InputService;
    public GameStateMachine StateMachine;

    public Game()
    {
        Debug.Log("Запущен коструктор Game");
        StateMachine = new GameStateMachine();
    }

}
