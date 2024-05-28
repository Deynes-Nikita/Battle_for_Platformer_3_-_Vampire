using UnityEngine;

[RequireComponent(typeof(MovementToTargetState))]
public class MovementToTargetTransitionState : TransitionState
{
    private TargetPointer _targetPointer;

    private void FixedUpdate()
    {
        if (_targetPointer.TryDefineTarget(out Vector2 tragetPoint))
        {
            IsTransitNeeded = true;
        }
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<MovementToTargetState>();
        _targetPointer = GetComponentInParent<TargetPointer>();
    }
}
