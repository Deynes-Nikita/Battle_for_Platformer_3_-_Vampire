using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isFaceRight = true;

    public event Action Turned;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction, float speedMove)
    {
        Vector2 offset = new Vector2(direction * speedMove, _rigidbody.velocity.y);
        _rigidbody.velocity = offset;

        Reflect(direction);
    }

    private void Reflect(float direction)
    {
        if ((direction > 0 && _isFaceRight == false) || (direction < 0 && _isFaceRight == true))
        {
            transform.rotation *= new Quaternion(0, -1, 0, 0);

            _isFaceRight = !_isFaceRight;
            Turned?.Invoke();
        }
    }
}
