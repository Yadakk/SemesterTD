using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTile : SelectableTile
{
    private Renderer tileRenderer;

    private GameObject occupyingPlaceable;

    public Vector3 TileHeight => new(0f, tileRenderer.bounds.extents.y, 0f);

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    public bool TryPlace(Placeable placeable)
    {
        if (occupyingPlaceable != null) return false;
        if (!placeable.TryBuy()) return false;

        var placedGO = Instantiate(placeable.Prefab, transform.position, transform.rotation, transform);
        var renderer = placedGO.GetComponent<Renderer>();
        var extents = renderer.bounds.extents;

        placedGO.transform.position += new Vector3(0f, extents.y, 0f);
        placedGO.transform.position += TileHeight;

        occupyingPlaceable = placedGO;
        return true;
    }
}