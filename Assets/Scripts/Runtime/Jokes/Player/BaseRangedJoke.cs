using UnityEngine;

public class BaseRangedJoke : MonoBehaviour, IJoke
{
    [SerializeField] private float _damage;
    [SerializeField] private float _projectilSpeed;
    [SerializeField] private RangedJokeProjectile _projectilePrefab;

    public void Make()
    {
        var projectile = SpawnProjectile();
        projectile.Throw(transform.forward, _projectilSpeed, _damage);
    }

    private RangedJokeProjectile SpawnProjectile()
    {
        return Instantiate(_projectilePrefab);
    }
}
