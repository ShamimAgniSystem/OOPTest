using System;
using UnityEngine;

public interface IPlayerState
{
    void EnterState();
    void Update();
    void FixedUpdate();
    void ExitState();
}

[System.Serializable]
public abstract class PlayerStateBase : IPlayerState
{
    protected PlayerLocomotion Controller;
    protected PlayerClass Player => Controller.GetPlayer();
    
    public virtual void Initialize(PlayerLocomotion controller)
    {
        this.Controller = controller;
    }
    
    public abstract PlayerStates StateType { get; }
    public abstract void EnterState();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void ExitState();
}

public abstract class StateMachine : PlayerStateBase
{
    // This maintains compatibility with your old StateMachine class
}