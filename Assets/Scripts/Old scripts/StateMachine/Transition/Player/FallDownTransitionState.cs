using UnityEngine;

[RequireComponent(typeof(FallDownState))]
public class FallDownTransitionState : TransitionState
{
    private readonly string GroundLayer = "Ground";

    private float _distance = 0.1f;
    private LayerMask _ground;

    private void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distance, _ground) == false)
            IsTransitNeeded = true;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<FallDownState>();
        _ground = LayerMask.GetMask(GroundLayer);
    }
}
