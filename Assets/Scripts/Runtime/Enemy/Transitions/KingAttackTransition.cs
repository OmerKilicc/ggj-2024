using UnityEngine;

public class KingAttackTransition : ITransition
{
    public IState ToState { get; set; }

    public bool Should = false;

    public bool ShouldTransition(StateMachine stateMachine)
    {
        return Should;
    }
}
