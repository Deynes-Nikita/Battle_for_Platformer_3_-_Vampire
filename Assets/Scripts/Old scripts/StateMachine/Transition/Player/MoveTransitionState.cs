using UnityEngine;

[RequireComponent(typeof(MovementState))]
public class MoveTransitionState : TransitionState
{
    private void Update()
    {
        if (Input.GetAxis(PlayerInputData.Params.Horizontal) != 0)
            IsTransitNeeded = true;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<MovementState>();
    }
}
