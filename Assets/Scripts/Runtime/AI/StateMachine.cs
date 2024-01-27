using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IState _currentState;
    protected Dictionary<IState, List<ITransition>> _transitions = new Dictionary<IState, List<ITransition>>();
    protected List<ITransition> _fromAnywhereTransitions = new List<ITransition>();

    protected virtual void Update()
    {
        CheckTransitions();
        _currentState?.OnTick(Time.deltaTime);
    }

    protected void AddTransitionFrom(IState fromState, ITransition transition)
    {
        if (!_transitions.ContainsKey(fromState))
        {
            _transitions[fromState] = new List<ITransition>();
        }

        _transitions[fromState].Add(transition);
    }

    protected void AddAnyTransition(ITransition transition)
    {
        _fromAnywhereTransitions.Add(transition);
    }

    private void CheckTransitions()
    {
        ITransition transition;

        if (AnyTransitionTriggered(out transition)
            || (_currentState != null && FromTransitionTriggered(_currentState, out transition)))
        {
            ChangeState(transition.ToState);
            return;
        }
    }

    private bool AnyTransitionTriggered(out ITransition transition)
    {
        transition = null;

        foreach (var t in _fromAnywhereTransitions)
        {
            if (!t.ShouldTransition(this))
                continue;

            transition = t;

            return true;
        }

        return false;
    }

    private bool FromTransitionTriggered(IState fromState, out ITransition transition)
    {
        transition = null;

        if (!_transitions.TryGetValue(fromState, out var transitions))
            return false;

        foreach (var t in transitions)
        {
            if (!t.ShouldTransition(this))
                continue;

            transition = t;

            return true;
        }

        return false;
    }

    protected void ChangeState(IState newState)
    {
        _currentState?.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}
