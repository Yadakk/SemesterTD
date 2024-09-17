using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTile : SelectableTile
{
    private Renderer tileRenderer;

    private GameObject currentPlaceable;

    public Vector3 TileHeight => new(0f, tileRenderer.bounds.extents.y, 0f);

    private void Awake()
    {
        tileRenderer = GetComponent<Renderer>();
    }

    public bool TryPlace(GameObject prefab)
    {
        if (currentPlaceable != null) return false;

        var placeable = Instantiate(prefab, transform.position, transform.rotation, transform);
        var renderer = placeable.GetComponent<Renderer>();
        var extents = renderer.bounds.extents;

        placeable.transform.position += new Vector3(0f, extents.y, 0f);
        placeable.transform.position += TileHeight;

        currentPlaceable = placeable;
        return true;
    }
}