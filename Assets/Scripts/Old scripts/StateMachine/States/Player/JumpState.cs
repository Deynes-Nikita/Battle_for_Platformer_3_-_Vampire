using UnityEngine;

public class JumpState : State
{
    [SerializeField] private float _forceJump = 7.0f;

    private void FixedUpdate()
    {
        Character.Rigidbody.AddForce(new Vector2(0, _forceJump), ForceMode2D.Impulse);

        Character.Animator.SetTrigger(AnimatorData.Params.IsJump);
    }
}
