using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlaceableTile : MonoBehaviour
{
    [SerializeField]
    private PlaceableType type;

    private Collider tileCollider;

    private GameObject occupyingPlaceable;

    public PlaceableType Type => type;

    private void Awake()
    {
        tileCollider = GetComponent<Collider>();
    }

    private void OnDrawGizmos()
    {
        if (tileCollider == null)
            tileCollider = GetComponent<Collider>();

        if (type == PlaceableType.None)
        {
            Gizmos.color = Color.black;
        }
        else if (type.HasFlag(PlaceableType.Road))
        {
            Gizmos.color = Color.yellow;
        }
        else if (type.HasFlag(PlaceableType.Slot))
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawCube(tileCollider.bounds.center + Vector3.up * 0.01f, tileCollider.bounds.extents * 2f);
    }

    public bool TryPlace(Placeable placeable)
    {
        if (occupyingPlaceable != null) return false;
        if (!placeable.TryBuy()) return false;

        var placedGO = Instantiate(placeable.Prefab, transform.position, transform.rotation, transform);
        var placeableCollider = placedGO.GetComponent<Collider>();
        placedGO.transform.position = placeableCollider.bounds.GetPositionOnTop(tileCollider.bounds);

        occupyingPlaceable = placedGO;
        return true;
    }
}