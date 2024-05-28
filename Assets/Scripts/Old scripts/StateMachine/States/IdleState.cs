using UnityEngine;

public class IdleState : State
{
    private void FixedUpdate()
    {
        Character.Rigidbody.velocity = Vector2.zero;
        float speed = Character.Rigidbody.velocity.magnitude;

        Character.Animator.SetFloat(AnimatorData.Params.Speed, speed);
    }
}
