using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] 
    private float maxDistance = 5f;

    private PlayerInteractionActions actions;

    private void Awake()
    {
        actions = new();
        actions.Main.OnInteract.started += OnInteractHandler;
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
        PlayerInteractionRaycaster.Raycast(maxDistance);
    }
}
