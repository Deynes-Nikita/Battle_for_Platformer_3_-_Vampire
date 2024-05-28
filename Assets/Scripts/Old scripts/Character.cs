using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _damage;

    [SerializeField] protected float MaxHealth;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Movement _movement;
    private CapsuleCollider2D _capsuleCollider;

    protected float CurrentHealth;

    public event Action<float, float> HealthChanged;

    public Rigidbody2D Rigidbody => _rigidbody;
    public Animator Animator => _animator;
    public Movement Movement => _movement;
    public CapsuleCollider2D CapsuleCollider => _capsuleCollider;
    public float Health => CurrentHealth;
    public float Damage => _damage;

    private void Awake()
    {
        GetComponents();
        SetParameters();
    }

    private void Start()
    {
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public void TakeDamage(float damage)
    {
        damage = Mathf.Abs(damage);
        ChangeHealth(-damage);
    }

    protected void ChangeHealth(float value)
    {
        CurrentHealth = Mathf.Clamp((CurrentHealth + value), 0, MaxHealth);

        HealthChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    protected virtual void GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    protected void SetParameters()
    {
        CurrentHealth = MaxHealth;
    }
}
