using UnityEngine;

public class MovementState : State
{
    [SerializeField] private float _walkSpeed = 1.0f;
    [SerializeField] private float _runSpeed = 4.0f;
    [SerializeField] private KeyCode _keyForRun = KeyCode.LeftShift;

    private Movement _movement;

    private bool _canRun = false;
    private float _horizontalMove;

    private void Update()
    {
        _horizontalMove = Input.GetAxis(PlayerInputData.Params.Horizontal);

        if (Input.GetKey(_keyForRun))
            _canRun = true;
        else
            _canRun = false;
    }

    private void FixedUpdate()
    {
        if (_canRun)
        {
            _movement.Move(_horizontalMove, _runSpeed);
        }
        else
        {
            _movement.Move(_horizontalMove, _walkSpeed);
        }

        Character.Animator.SetFloat(AnimatorData.Params.Speed, Mathf.Abs(Character.Rigidbody.velocity.x));
    }

    protected override void GetComponents()
    {
        base.GetComponents();
        _movement = Character.Movement;
    }
}
