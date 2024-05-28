using UnityEngine;

public class AttackToTargetState : State
{
    private readonly string AttackAnimation = "Attack";

    private  WeaponArea _weaponArea;
    private Character _target;

    public override void Enter()
    {
        base.Enter();
        _target = null;
        Character.Animator.SetTrigger(AnimatorData.Params.IsAttack);
        _weaponArea.Detected += Attack;
    }

    public override void Exit()
    {
        if (Character.Animator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimation))
            return;

        base.Exit();
        _weaponArea.Detected -= Attack;
    }

    protected override void GetComponents()
    {
        base.GetComponents();

        _weaponArea = Character.gameObject.GetComponentInChildren<WeaponArea>();
    }

    private void Attack(Collider2D collider)
    {
        if (collider == null)
            return;

        collider.TryGetComponent<Character>(out _target);

        if (_target != null)
        {
            _target.TakeDamage(Character.Damage);
        }
    }
}