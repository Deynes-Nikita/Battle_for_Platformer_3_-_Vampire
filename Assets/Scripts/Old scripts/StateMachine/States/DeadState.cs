using UnityEngine;

public class DeadState : State
{
    [SerializeField] private float _timeToDestroy = 1f;
    
    private float _currentTime;

    private void FixedUpdate()
    {
        _currentTime += Time.fixedDeltaTime;

        if ( _currentTime >= _timeToDestroy)
        {
            Destroy(Character.gameObject);
        }
    }

    public override void Enter()
    {
        base.Enter();

        Character.Animator.SetTrigger(AnimatorData.Params.IsDead);

        Character.CapsuleCollider.enabled = false;
        Character.Rigidbody.isKinematic = true;
        Character.Rigidbody.velocity = Vector2.zero;
    }
}
