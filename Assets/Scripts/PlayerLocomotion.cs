using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerClass))]
public class PlayerLocomotion : MonoBehaviour
{
    public PlayerClass GetPlayer() => player;
    
    [Header("State Machine")]
    [SerializeField] private PlayerIdleState _idlePlayerState;
    [SerializeField] private PlayerRunningState _runningPlayerState;
    [SerializeField] private PlayerCollectingState _collectingPlayerState;
    [SerializeField] private PlayerDeliveryState _deliveringPlayerState;
    
    private Dictionary<PlayerStates, PlayerStateBase> stateMachine = new Dictionary<PlayerStates, PlayerStateBase>();
    [SerializeField] private PlayerStates currentStateKey = PlayerStates.Idle;
    public PlayerStates GetCurrentStateKey => currentStateKey;
    
    
    
    private PlayerStateBase CurrentState { 
        get
        {
            if (stateMachine.TryGetValue(currentStateKey, out PlayerStateBase state)) return state; // tarnery
            return null;
        } 
    }
    
    private bool bSwitchingState = false;
    private PlayerClass player;

    private void Awake()
    {
        player = GetComponent<PlayerClass>();
    }

    private void Start()
    {
        InitStates();
    }
    public void InitStates()
    {
        _idlePlayerState = new PlayerIdleState();
        _runningPlayerState = new PlayerRunningState();
        _collectingPlayerState = new PlayerCollectingState();
        _deliveringPlayerState = new PlayerDeliveryState();
        
        AddToStateMachine(_idlePlayerState);
        AddToStateMachine(_runningPlayerState);
        AddToStateMachine(_collectingPlayerState);
        AddToStateMachine(_deliveringPlayerState);
        
        SwitchState(PlayerStates.Idle);
    }
    private void Update()
    {
        CurrentState?.Update();
    }
    private void FixedUpdate()
    {
        if (bSwitchingState)
        {
            bSwitchingState = false;
            return;
        }
        CurrentState?.FixedUpdate();
    }

    #region State Machine Methods
    void AddToStateMachine(PlayerStateBase state)
    {
        state.Initialize(this);
        stateMachine.Add(state.StateType, state);
    }
    
    public void SwitchState(PlayerStates newState)
    {
        if (currentStateKey == newState) return;
        
        bSwitchingState = true;
        PlayerStateBase prevState = CurrentState;
        currentStateKey = newState;
        prevState?.ExitState();
        CurrentState?.EnterState();
    }

    #endregion

    #region Input Methods
    public bool IsMovingInput()
    { 
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }
    
    public bool IsCollectInput()
    {
        return Input.GetKeyDown(KeyCode.C);
    }
    
    public bool IsDeliverInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    #endregion
}