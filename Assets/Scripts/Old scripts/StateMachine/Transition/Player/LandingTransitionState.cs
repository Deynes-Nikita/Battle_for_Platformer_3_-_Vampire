using UnityEngine;

[RequireComponent(typeof(LandingState))]
public class LandingTransitionState : TransitionState
{
    private readonly string GroundLayer = "Ground";

    private float _distance = 2f;
    private LayerMask _ground;

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distance, _ground))
            IsTransitNeeded = true;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<LandingState>();
        _ground = LayerMask.GetMask(GroundLayer);
    }
}
