using UnityEngine;

public class RangedJokeProjectile : MonoBehaviour
{
    private const float LIFETIME = 20f;

    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private GameObject _visuals;

    private float _speed;
    private float _damage;

    private Transform _transform;
    private bool _move = false;

    private void Awake()
    {
        _transform = transform;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITarget>(out var target))
        {
            target.Hit(_damage);
        }

        StopProjectile();
    }

    public void Throw(Vector3 direction, float speed, float damage)
    {
        _move = true;

        _transform.forward = direction;
        
        _speed = speed;
        _damage = damage;

        Destroy(gameObject, LIFETIME);
    }

    private void Update()
    {
        if (!_move)
            return;

        MoveProjectile();
    }

    private void MoveProjectile()
    {
        float speed = _speed * Time.deltaTime;
        _transform.position += _transform.forward * speed;
    }

    private void StopProjectile()
    {
        _move = false;
        _hitParticles.Play();

        _visuals.SetActive(false);
        Destroy(gameObject, 5);
    }
}
