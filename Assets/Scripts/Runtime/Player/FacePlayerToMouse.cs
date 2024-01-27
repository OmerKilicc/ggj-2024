using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class FacePlayerToMouse : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10f;

    private Transform _transform;
    private InputsSystem _inputs;
    private Camera _camera;

    private Vector3 _targetPos = Vector3.zero;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _camera = Camera.main;

        _inputs = new InputsSystem();

        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
        _inputs.Dispose();
    }

    private void Update()
    {
        Vector2 mousePos = _inputs.Character.LookPosition.ReadValue<Vector2>();

        MouseMoveCallback(mousePos);
        LookAtWorldPos(_targetPos, _rotationSpeed * Time.deltaTime);
    }

    private void MouseMoveCallback(Vector2 mousePos)
    {
        if (_camera == null)
        {
            _camera = Camera.main;
            return;
        }

        LookAtMousePos(mousePos);
    }

    private void LookAtMousePos(Vector2 mousePos)
    {
        Ray ray = _camera.ScreenPointToRay(mousePos);
        float height = _camera.transform.position.y - transform.position.y;

        float lineDist = Mathf.Abs(height / ray.direction.y);

        _targetPos = ray.origin + ray.direction * lineDist;
    }

    private void LookAtWorldPos(Vector3 pos, float delta)
    {
        Vector3 dir = pos - _transform.position;
        dir.y = 0f;

        dir.Normalize();

        _transform.forward = Vector3.Lerp(_transform.forward, dir, delta);
    }
}
