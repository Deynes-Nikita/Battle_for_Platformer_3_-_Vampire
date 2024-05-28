using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ColliderTrackingArea : MonoBehaviour
{
    private Collider _collider;

    public event Action<Collider2D> Detected;

    public Collider Collider => _collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectCharacter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DetectCharacter(collision = null);
    }

    private void DetectCharacter(Collider2D collider)
    {
        Detected?.Invoke(collider);
    }
}
