using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class TileSelector : MonoBehaviour
{
    [SerializeField]
    private Vector2 cellSize = new(1f, 1f);

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Application.isPlaying) return;
        UpdateLines();
    }

    private void UpdateLines()
    {
        LineRendererShapeDrawer.DrawSquare(lineRenderer, cellSize);
    }
}