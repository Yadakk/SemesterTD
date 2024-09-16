using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StrategyCamera : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 0.01f;

    private StrategyCameraActions actions;

    private void Awake()
    {
        actions = new();
        actions.Main.OnPan.started += OnPanHandler;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnPanHandler(InputAction.CallbackContext context)
    {
        Vector3 horizontalRotationEuler = transform.rotation.eulerAngles;
        horizontalRotationEuler.x = 0f;
        Quaternion horizontalRotation = Quaternion.Euler(horizontalRotationEuler);

        Vector2 delta = context.ReadValue<Vector2>();

        Vector3 transformDelta = horizontalRotation * new Vector3(delta.x, 0f, delta.y);
        transform.position += -transformDelta * sensitivity;
    }
}