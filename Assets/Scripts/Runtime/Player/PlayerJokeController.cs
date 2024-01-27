using UnityEngine;

public class PlayerJokeController : MonoBehaviour
{
    [SerializeField] Component _baseJokeComponent;
    [SerializeField] Component _bigJoke1Component;
    [SerializeField] Component _bigJoke2Component;
    [SerializeField] Component _bigJoke3Component;

    private InputsSystem _input;

    private IJoke _selectedJoke;

    private IJoke _baseJoke;
    private IJoke _bigJoke1;
    private IJoke _bigJoke2;
    private IJoke _bigJoke3;

    private void Awake()
    {
        _baseJoke = _baseJokeComponent as IJoke;
        _selectedJoke = _baseJoke;
    }

    private void OnEnable()
    {
        _input = new InputsSystem();
        _input.Enable();

        _input.Jokes.UseJoke.performed += JokePerformedCallback;
        _input.Jokes.SwitchToBaseJoke.performed += SwitchToBaseJokeCallback;
        _input.Jokes.SwitchToBigJoke1.performed += SwitchToBigJoke1Callback;
        _input.Jokes.SwitchToBigJoke2.performed += SwitchToBigJoke2Callback;
        _input.Jokes.SwitchToBigJoke3.performed += SwitchToBigJoke3Callback;
    }

    private void OnDisable()
    {
        _input.Jokes.UseJoke.performed -= JokePerformedCallback;
        _input.Jokes.SwitchToBaseJoke.performed -= SwitchToBaseJokeCallback;
        _input.Jokes.SwitchToBigJoke1.performed -= SwitchToBigJoke1Callback;
        _input.Jokes.SwitchToBigJoke2.performed -= SwitchToBigJoke2Callback;
        _input.Jokes.SwitchToBigJoke3.performed -= SwitchToBigJoke3Callback;

        _input.Disable();
        _input.Dispose();
    }

    private void JokePerformedCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _selectedJoke.Make();
    }

    private void SwitchToBaseJokeCallback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        _selectedJoke = _baseJoke;
    }

    private void SwitchToBigJoke1Callback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        throw new System.NotImplementedException();
    }

    private void SwitchToBigJoke2Callback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        throw new System.NotImplementedException();
    }

    private void SwitchToBigJoke3Callback(UnityEngine.InputSystem.InputAction.CallbackContext cbc)
    {
        throw new System.NotImplementedException();
    }
}
