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

    public MapTile SelectedTile { get; private set; }

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

        var tile = ComponentRaycaster.Raycast<MapTile>(cam.ScreenPointToRay(Input.mousePosition));

        SelectedTile = tile;

        if (tile == null)
        {
            outline.Deselect();
            return;
        }

        if (tile.Type == MapTileType.None)
        {
            outline.Deselect();
            return;
        }

        var tileCollider = tile.GetComponent<Collider>();
        Vector3 tileBounds = tileCollider.bounds.extents;
        Vector2 tileWidth = new(tileBounds.x * 2, tileBounds.z * 2);
        outline.Select(tile.transform.position + Vector3.up * 0.01f, tileWidth);
    }
}
