using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SelectionOutline : MonoBehaviour
{
    [SerializeField]
    private Vector2 selectionSize = new(1f, 1f);

    private LineRenderer lineRenderer;

    private Vector3 previousPosition;

    public static SelectionOutline Instance { get; private set; }

    private void Awake()
    {
        SetLineRenderer();
        UpdateLines();

        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
    }

    private void Update()
    {
        if (previousPosition == transform.position) return;
        previousPosition = transform.position;
        UpdateLines();
    }

    private void OnValidate()
    {
        UpdateLines();
    }

    public void Select(Vector3 pos, Vector2 size)
    {
        transform.position = pos;
        selectionSize = size;
        UpdateLines();
    }

    private void UpdateLines()
    {
        SetLineRenderer();
        LineRendererShapeDrawer.DrawSquare(lineRenderer, selectionSize);
    }

    private void SetLineRenderer()
    {
        if (lineRenderer == null) lineRenderer = GetComponentInChildren<LineRenderer>();
    }
}