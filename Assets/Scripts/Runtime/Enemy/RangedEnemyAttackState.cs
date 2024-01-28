using System;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyAttackState : MonoBehaviour, IState
{
	[SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Component _jokeComponent;
    private IJoke _joke;

    private Transform _transform;
    private Transform _playerTransform;

    private float _passedTime = 0f;

    public void OnEnter()
    {
        _transform = transform;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        _joke = _jokeComponent as IJoke;

        GetClose();
    }

    public void OnExit()
    {
    }

    public void OnTick(float deltaTime)
    {
        Vector3 dir = _playerTransform.position - _transform.position;

        float distSq = dir.sqrMagnitude;

        dir.Normalize();

        _agent.transform.forward = dir;

        _passedTime += deltaTime;

        if (_passedTime > 3f)
        {
            _passedTime = 0f;
            _joke.Make();
        }

        if (distSq < 255)
            return;

        GetClose();
    }

    private void GetClose()
    {
        Vector3 dir = _playerTransform.position - _transform.position;

        dir.Normalize();

        Vector3 pos = _playerTransform.position - dir * 10f;

        _agent.SetDestination(pos);
    }
}
