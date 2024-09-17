using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class StrategyCameraTileSelector : MonoBehaviour
{
    private StrategyCameraSelectorActions actions;
    private Camera cam;
    private SelectionOutline outline;

    public SelectableTile SelectedTile { get; private set; }

    private void Awake()
    {
        actions = new();
        actions.Main.OnSelect.started += OnSelectHandler;

        cam = GetComponent<Camera>();
        outline = FindObjectOfType<SelectionOutline>();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void OnSelectHandler(InputAction.CallbackContext context)
    {
        if (PointerOnUI.Check()) return;

        var tile = ComponentRaycaster.Raycast<SelectableTile>(cam.ScreenPointToRay(Input.mousePosition));
        SelectedTile = tile;

        if (tile == null)
        {
            outline.Deselect();
            return;
        }

        var tileRenderer = tile.GetComponent<Renderer>();
        Vector3 tileBounds = tileRenderer.bounds.extents;
        Vector2 tileWidth = new(tileBounds.x * 2, tileBounds.z * 2);
        Vector3 tileHeight = new(0f, tileBounds.y + 0.01f, 0f);
        outline.Select(tile.transform.position + tileHeight, tileWidth);
    }
}
