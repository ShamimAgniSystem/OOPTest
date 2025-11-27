using UnityEngine;

[System.Serializable]
public class PlayerRunningState : PlayerStateBase
{
    public override PlayerStates StateType => PlayerStates.Running;

    public override void EnterState()
    {
        Debug.Log("Player started Running");
    }

    public override void Update()
    {
        if (!Controller.IsMovingInput())
            Controller.SwitchState(PlayerStates.Idle);
            
        if (Controller.IsCollectInput())
            Controller.SwitchState(PlayerStates.Collecting);
            
        if (Controller.IsDeliverInput())
            Controller.SwitchState(PlayerStates.Delivering);
    }

    public override void FixedUpdate()
    {
        // Move player forward
        Player.Move();
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Running State");
    }
}