using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MapTile : MonoBehaviour
{
    [SerializeField]
    private MapTileType type;

    private Collider tileCollider;

    private GameObject occupyingPlaceable;

    public MapTileType Type => type;

    private void Awake()
    {
        tileCollider = GetComponent<Collider>();
    }

    private void OnDrawGizmos()
    {
        if (tileCollider == null)
            tileCollider = GetComponent<Collider>();

        if (type == MapTileType.None)
        {
            Gizmos.color = Color.black;
        }
        else if (type.HasFlag(MapTileType.Road))
        {
            Gizmos.color = Color.yellow;
        }
        else if (type.HasFlag(MapTileType.Slot))
        {
            Gizmos.color = Color.green;
        }
        else if (type.HasFlag(MapTileType.EnemySource))
        {
            Gizmos.color = Color.red;
        }
        else if (type.HasFlag(MapTileType.Tower))
        {
            Gizmos.color = Color.cyan;
        }

        Gizmos.DrawCube(tileCollider.bounds.center + Vector3.up * 0.01f, tileCollider.bounds.extents * 2f);
    }

    public bool TryPlace(Placeable placeable)
    {
        if (occupyingPlaceable != null) return false;
        if (!placeable.TryBuy()) return false;

        var placedGO = Instantiate(placeable.Prefab, transform);
        placedGO.transform.localScale = placedGO.transform.localScale.InverseScale(transform.localScale);

        bool boundsSetFlag = false;
        Bounds combinedBounds = new();
        Renderer[] renderers = placedGO.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (!boundsSetFlag)
            {
                combinedBounds = renderer.bounds;
                boundsSetFlag = true;
            }

            combinedBounds.Encapsulate(renderer.bounds);
        }

        placedGO.transform.position = combinedBounds.GetPositionOnTop(tileCollider.bounds);

        occupyingPlaceable = placedGO;
        return true;
    }
}