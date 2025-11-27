using UnityEngine;

[System.Serializable]
public class PlayerDeliveryState : PlayerStateBase
{
    public override PlayerStates StateType => PlayerStates.Delivering;

    public override void EnterState()
    {
        Debug.Log("Delivering item...");
        // Backpack.Instance.PopItem();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            Controller.SwitchState(PlayerStates.Idle);
            
        if (Controller.IsMovingInput())
            Controller.SwitchState(PlayerStates.Running);
    }

    public override void FixedUpdate()
    {
        // Delivering doesn't need movement
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Delivering State");
    }
}