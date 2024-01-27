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
    }

    public void Move(Vector2 vector)
    {
        _move = new Vector3(vector.x, 0f, vector.y);
    }

    private void MoveCharacter()
    {
        Vector3 gravity = Physics.gravity;
        Vector3 move = gravity + _move;

        move *= Time.deltaTime * _moveSpeed;

        _controller.Move(move);
    }
}
