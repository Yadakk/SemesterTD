using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class StrategyCameraInteraction : MonoBehaviour
{
    private StrategyCameraInteractionActions actions;
    private Camera cam;

    private void Awake()
    {
        actions = new();
        actions.Main.OnInteract.started += OnInteractHandler;
        cam = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnInteractHandler(InputAction.CallbackContext context)
    {
        InteractionRaycaster.Raycast(cam.ScreenPointToRay(Input.mousePosition));
    }
}
