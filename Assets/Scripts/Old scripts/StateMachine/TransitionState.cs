using UnityEngine;

public abstract class TransitionState : MonoBehaviour
{
    public State TargetState {get; protected set;}
    public bool IsTransitNeeded { get; protected set; }

    private void OnEnable()
    {
        IsTransitNeeded = false;
    }

    private void Start()
    {
        GetComponents();
    }

    protected abstract void GetComponents();
}