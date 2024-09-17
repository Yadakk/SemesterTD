using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitPathNode))]
[RequireComponent(typeof(Collider))]
public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject testUnit;

    private UnitPathNode node;
    private Collider col;

    public Vector3 Extents => col.bounds.extents;
    public Vector3 HalfHeight => Vector3.up * Extents.y;

    private void Awake()
    {
        node = GetComponent<UnitPathNode>();
        col = GetComponent<Collider>();
    }

    private void Start()
    {
        SpawnUnit(testUnit);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + new Vector3(0f, 1f, 0f), Vector3.one * 0.4f);
    }

    public void SpawnUnit(GameObject prefab)
    {
        var unit = Instantiate(prefab, transform.position, transform.rotation, transform.parent);

        Collider unitCollider = unit.GetComponent<Collider>();
        Vector3 unitExtents = unitCollider.bounds.extents;
        Vector3 unitHalfHeight = Vector3.up * unitExtents.y;

        unit.transform.position += unitHalfHeight + HalfHeight;

        var unitBehaviour = unit.GetComponent<Unit>();
        unitBehaviour.SetCurrentNode(node);
    }
}
