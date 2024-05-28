using UnityEngine;

[RequireComponent(typeof(DeadState))]
public class DeadTransitionState : TransitionState
{
    protected Character _character;

    private void FixedUpdate()
    {
        if (_character.Health == 0)
        {
            IsTransitNeeded = true;
        }
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<DeadState>();
        _character = transform.parent.gameObject.GetComponent<Character>();
    }
}
