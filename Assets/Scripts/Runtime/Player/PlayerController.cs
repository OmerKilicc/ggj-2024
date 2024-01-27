using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputsSystem _inputs;
    IMover _mover;

    private Vector2 _lastMove;
    private float _multiplier = 1f;

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
        _inputs.Character.Run.performed += OnRunCallback;
        _inputs.Character.Run.canceled += OnRunCancleCallback;
    }

    private void UnsubscribeEvents()
    {
        _inputs.Character.Movement.performed -= OnMoveCallback;
        _inputs.Character.Movement.canceled -= OnMoveEndCallback;
        _inputs.Character.Run.performed -= OnRunCallback;
        _inputs.Character.Run.canceled -= OnRunCancleCallback;
    }

    private void OnMoveCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _lastMove = cbc.ReadValue<Vector2>();
        _mover.Move(_lastMove * _multiplier);
    }

    private void OnMoveEndCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _mover.Move(Vector2.zero);
    }

    private void OnRunCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _multiplier = 2f;
        _mover.Move(_lastMove * _multiplier);
    }

    private void OnRunCancleCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _multiplier = 1f;
        _mover.Move(_lastMove * _multiplier);
    }
}
