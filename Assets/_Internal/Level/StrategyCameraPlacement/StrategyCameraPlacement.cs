using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StrategyCameraPlacement : MonoBehaviour
{
    private GameObject selectedPrefab;
    private Camera cam;

    private StrategyCameraPlacementActions actions;

    private void Awake()
    {
        actions = new();
        actions.Main.OnPlace.started += OnPlaceHandler;

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

    private void OnPlaceHandler(InputAction.CallbackContext context)
    {
        var tile = ComponentRaycaster.Raycast<PlaceableTile>(cam.ScreenPointToRay(Input.mousePosition));
        if (tile == null) return;

        if (!tile.TryPlace(selectedPrefab)) return;
        selectedPrefab = null;
    }

    public void SelectPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;
    }
}
