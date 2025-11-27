using UnityEngine;

[System.Serializable]
public class PlayerCollectingState : PlayerStateBase
{
    public override PlayerStates StateType => PlayerStates.Collecting;

    public override void EnterState()
    {
        Debug.Log("Collecting item...");
        // Backpack.Instance.PushItem(new ItemData { itemName = "Potion" });
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
        // Collecting doesn't need movement
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Collecting State");
    }
}