using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputsSystem _inputs;
    IMover _mover;

    private void Awake()
    {
        _mover = GetComponent<IMover>();
    }

    private void OnEnable()
    {
        _inputs = new InputsSystem();
        _inputs.Enable();

        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();

        _inputs.Disable();
        _inputs.Dispose();
    }

    private void SubscribeEvents()
    {
        _inputs.Character.Movement.performed += OnMoveCallback;
        _inputs.Character.Movement.canceled += OnMoveEndCallback;
    }

    private void UnsubscribeEvents()
    {
        _inputs.Character.Movement.performed -= OnMoveCallback;
        _inputs.Character.Movement.canceled -= OnMoveEndCallback;
    }

    private void OnMoveCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        Vector2 moveVector = cbc.ReadValue<Vector2>();
        _mover.Move(moveVector);
    }

    private void OnMoveEndCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _mover.Move(Vector2.zero);
    }
}
