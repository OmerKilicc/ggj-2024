using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private const string X_AXIS_PARAMETER = "move-x";
    private const string Y_AXIS_PARAMETER = "move-y";

    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;

    [Space]
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] float _lerpSpeed = 5f;

    private Vector3 _targetVelocity;
    private Vector3 _velocity;

    private void Start()
    {
        _velocity = _targetVelocity = _controller.velocity;
    }

    private void Update()
    {
        Vector3 forward = _controller.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        _targetVelocity = _controller.velocity;
        _targetVelocity.y = 0f;
        _targetVelocity = Vector3.ClampMagnitude(_targetVelocity, _maxSpeed);

        float offsetAngle = Vector3.SignedAngle(forward, Vector3.forward, Vector3.up);
        _targetVelocity = Quaternion.AngleAxis(offsetAngle, Vector3.up) * _targetVelocity;

        _velocity = Vector3.Lerp(_velocity, _targetVelocity, Time.deltaTime * _lerpSpeed);

        _animator.SetFloat(X_AXIS_PARAMETER, _velocity.x / _maxSpeed);
        _animator.SetFloat(Y_AXIS_PARAMETER, _velocity.z / _maxSpeed);
    }
}
