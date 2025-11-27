using UnityEngine;

[System.Serializable]
public class PlayerIdleState : PlayerStateBase
{
    public override PlayerStates StateType => PlayerStates.Idle;

    public override void EnterState()
    {
        Debug.Log("Player entered Idle State");
    }

    public override void Update()
    {
        if (Controller.IsMovingInput())
            Controller.SwitchState(PlayerStates.Running);
            
        if (Controller.IsCollectInput())
            Controller.SwitchState(PlayerStates.Collecting);
    }

    public override void FixedUpdate()
    {
        
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }
}