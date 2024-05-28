using UnityEngine;

public class LandingState : State
{
    private void FixedUpdate()
    {
        Character.Animator.SetTrigger(AnimatorData.Params.IsLanding);
    }
}
