using UnityEngine;

public class FallDownState : State
{
    private void FixedUpdate()
    {
        Character.Animator.SetTrigger(AnimatorData.Params.IsFallDown);
    }
}
