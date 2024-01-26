using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour, IMover
{
    CharacterController _controller;

    private Vector3 _move = Vector3.zero;

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _rotateSpeed = 10f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveCharacter();
        FaceCharacter();
    }

    public void Move(Vector2 vector)
    {
        _move = vector;
    }

    private void MoveCharacter()
    {
        Vector3 gravity = Physics.gravity;
        Vector3 move = gravity + _move;

        move *= Time.deltaTime * _moveSpeed;

        _controller.Move(move);
    }

    private void FaceCharacter()
    {
        if (_move == Vector3.zero)
            return;

        Vector3 lookDir = new Vector3(_move.x, 0, _move.y);

        float speed = _rotateSpeed * Time.deltaTime;

        _controller.transform.forward = Vector3.Lerp(_controller.transform.forward, lookDir, speed);
    }
}
