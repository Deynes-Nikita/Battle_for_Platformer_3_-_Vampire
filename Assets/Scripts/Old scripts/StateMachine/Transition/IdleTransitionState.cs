using UnityEngine;

[RequireComponent(typeof(IdleState))]
public class IdleTransitionState : TransitionState
{
    private Character _character;

    private void FixedUpdate()
    {
       float currentSpeed = _character.Rigidbody.velocity.magnitude;

        if (currentSpeed == 0)
            IsTransitNeeded = true;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<IdleState>();

        if (transform.parent.TryGetComponent<Character>(out _character) == false)
        {
            _character = transform.parent.gameObject.AddComponent<Character>();
        }
    }
}