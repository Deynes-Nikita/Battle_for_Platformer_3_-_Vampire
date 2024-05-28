using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<TransitionState> _transitions;

    protected Character Character;

    private void Awake()
    {
        GetComponents();
    }

    public virtual void Enter()
    {
        if(enabled == false)
        {
            enabled = true;

            foreach (var transaction in _transitions)
                transaction.enabled = true;
        }
    }

    public State GetNext()
    {
        foreach (var transition in _transitions)
        {
            if (transition.IsTransitNeeded)
                return transition.TargetState;
        }

        return null;
    }

    public virtual void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    protected virtual void GetComponents()
    {
        if (transform.parent.TryGetComponent<Character>(out Character) == false)
        {
            Character = transform.parent.gameObject.AddComponent<Character>();
        }
    }
}
