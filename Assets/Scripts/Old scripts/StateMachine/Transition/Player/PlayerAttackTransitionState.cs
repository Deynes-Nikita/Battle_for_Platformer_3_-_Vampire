using UnityEngine;

[RequireComponent(typeof(AttackToTargetState))]
public class PlayerAttackTransitionState : TransitionState
{
    [SerializeField] private float _delayLastAttack = 1f;

    private float _lastAttackTime;

    private void Update()
    {
        if (Input.GetAxis(PlayerInputData.Params.Attack) != 0 && _lastAttackTime == _delayLastAttack)
        {
            IsTransitNeeded = true;
            _lastAttackTime = 0;
        }

        if (_lastAttackTime > _delayLastAttack)
            _lastAttackTime = _delayLastAttack;
        else
            _lastAttackTime += Time.deltaTime;
    }

    protected override void GetComponents()
    {
        TargetState = GetComponent<AttackToTargetState>();
    }
}
