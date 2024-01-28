using UnityEngine;

public class KingTripleShoot : MonoBehaviour, IJoke
{
    [SerializeField] RangedJokeProjectile _prefab;
    [SerializeField] Transform _dir1;
    [SerializeField] Transform _dir2;
    [SerializeField] Transform _dir3;

    [Space]
    [SerializeField] float _speed = 20;
    [SerializeField] float _damage = 10;

    public void Make()
    {
        var player = Player.Instance;

        Vector3 dir = player.transform.position - transform.position;
        transform.forward = dir.normalized;

        ThrowProjectiles();
    }

    private void ThrowProjectiles()
    {
        var projectile1 = Instantiate(_prefab);
        var projectile2 = Instantiate(_prefab);
        var projectile3 = Instantiate(_prefab);

        projectile1.transform.position = transform.position;
        projectile2.transform.position = transform.position;
        projectile3.transform.position = transform.position;

        projectile1.Throw(_dir1.forward, _speed, _damage);
        projectile2.Throw(_dir2.forward, _speed, _damage);
        projectile3.Throw(_dir3.forward, _speed, _damage);
    }
}
