using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionOutline : MonoBehaviour
{
    [SerializeField]
    private Vector2 selectionSize = new(1f, 1f);

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();

        Deselect();
    }

    public void Select(Vector3 pos, Vector2 size)
    {
        gameObject.SetActive(true);

        transform.position = pos;
        selectionSize = size;
        UpdateLines();
    }

    public void Deselect()
    {
        gameObject.SetActive(false);
    }

    private void UpdateLines()
    {
        LineRendererShapeDrawer.DrawSquare(lineRenderer, selectionSize);
    }
}