using UnityEngine;

[RequireComponent(typeof(AttackToTargetState))]
public class AttackToTargetTransitionState : TransitionState
{
    [SerializeField] private float _distanceToTarget = 0.2f;
    
    private TargetPointer _targetPointer;
    private Player _target;

    private void FixedUpdate()
    {
        _target = _targetPointer.GetTargetPlayer();

        if (_target != null && Vector2.Distance(transform.parent.position, _target.transform.position) < _distanceToTarget)
        {
            IsTransitNeeded = true;
        }
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<AttackToTargetState>();
        _targetPointer = GetComponentInParent<TargetPointer>();
    }
}
