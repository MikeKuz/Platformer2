using UnityEngine;

public class GameBootstrapper : MonoBehaviour //ICoroutineRunner
{

    private Game _game;

    private void Awake()
    {
        Debug.Log("awake");
        _game = new Game();
        _game.StateMachine.Enter<BootstrapState>();
        DontDestroyOnLoad(this);
        //_game.State
    }
}