using UnityEngine;

public class Enemy : MonoBehaviour, ITarget
{
    [SerializeField] Animator _animator;
    [SerializeField] private float _enemyBaseHealth = 50f;
    [SerializeField] GameObject _destroyOnDeath;

    public void Hit(float damage)
    {
        if (_enemyBaseHealth <= 0)
            EnemyDeathSequence();

        _enemyBaseHealth -= damage;
    }

    private void EnemyDeathSequence()
    {
        _animator.SetTrigger("laugh");

        if (_destroyOnDeath != null)
            Destroy(_destroyOnDeath);

        if (TryGetComponent<StateMachine>(out var sm))
        {
            sm.enabled = false;
        }
    }
}
