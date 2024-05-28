using UnityEngine;

public class MovementToTargetState : State
{
    [SerializeField] private float _speed = 1f;

    private Transform _transformParent;
    private TargetPointer _targetPointer;

    private void FixedUpdate()
    {
        _targetPointer.TryDefineTarget(out Vector2 currentTargetPosition);
        float direction = Mathf.Sign(currentTargetPosition.x - _transformParent.position.x);
        Character.Movement.Move(direction, _speed);

        float speed = Mathf.Abs(Character.Rigidbody.velocity.x);
        Character.Animator.SetFloat(AnimatorData.Params.Speed, speed);
    }

    protected override void GetComponents()
    {
        base.GetComponents();

        _targetPointer = GetComponentInParent<TargetPointer>();
        _transformParent = transform.parent;
    }
}
