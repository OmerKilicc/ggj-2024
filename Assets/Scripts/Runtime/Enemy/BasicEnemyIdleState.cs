using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyIdleState : MonoBehaviour, IState
{
    [SerializeField] private float _minWaitBeforeMove;
    [SerializeField] private float _maxWaitBeforeMove;

    [Space]
    [SerializeField] private NavMeshAgent _navAgent;

    [Space]
    [SerializeField] private float _walkDistance = 5f;

    private float _waitTime = 0f;
    private float _passedTime = 0f;

    public void OnEnter()
    {
        _waitTime = Random.Range(_minWaitBeforeMove, _maxWaitBeforeMove);
    }

    public void OnExit()
    {
    }

    public void OnTick(float deltaTime)
    {
        _passedTime += deltaTime;

        if (_passedTime < _waitTime)
            return;

        MoveToNewPosition();

        _passedTime = 0f;
        _waitTime = Random.Range(_minWaitBeforeMove, _maxWaitBeforeMove);
    }

    private void MoveToNewPosition()
    {
        Vector3 rndPos = transform.position + Random.insideUnitSphere * _walkDistance;
        _navAgent.SetDestination(rndPos);
    }
}
