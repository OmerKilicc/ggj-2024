using UnityEngine;

public class BaseRangedJoke : MonoBehaviour, IJoke
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damage;
    [SerializeField] private float _projectilSpeed;
    [SerializeField] private RangedJokeProjectile _projectilePrefab;

    public void Make()
    {
        var projectile = SpawnProjectile();
        projectile.Throw(transform.forward, _projectilSpeed, _damage);

        _animator?.SetTrigger("shoot");
    }

    private RangedJokeProjectile SpawnProjectile()
    {
        RangedJokeProjectile projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = transform.position;

        return projectile;
    }
}
