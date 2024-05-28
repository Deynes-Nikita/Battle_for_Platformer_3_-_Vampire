using UnityEngine;

[RequireComponent(typeof(JumpState))]
public class JumpTransitionState : TransitionState
{
    private void Update()
    {
        if (Input.GetAxis(PlayerInputData.Params.Jump) != 0)
            IsTransitNeeded = true;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<JumpState>();
    }
}
