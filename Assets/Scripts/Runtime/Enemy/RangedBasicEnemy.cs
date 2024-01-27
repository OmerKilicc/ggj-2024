using AI;
using UnityEngine;

public class RangedBasicEnemy : StateMachine
{
    [Header("States")]
    [SerializeField] private BasicEnemyIdleState _idleState;
    [SerializeField] private RangedEnemyAttackState _attackState;

    [Space]
    [Header("Transitions")]
    [SerializeField] private OnPlayerEnterSphere _onPlayerEnterSphere;
    [SerializeField] private OnPlayerExitSphere _onPlayerExitSphere;

    void Start()
    {
        ChangeState(_idleState);

        _onPlayerEnterSphere.ToState = _attackState;
        AddTransitionFrom(_idleState, _onPlayerEnterSphere);

        _onPlayerExitSphere.ToState = _idleState;
        AddTransitionFrom(_attackState, _onPlayerExitSphere);
    }
}
