using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;

    private void Update()
    {
        Vector3 velocity = _agent.velocity;
        float normalizedSpeed = velocity.magnitude / _speed;

        _animator.SetFloat("move", normalizedSpeed);
    }
}
