using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LineRendererShapeDrawer
{
    public static void DrawSquare(LineRenderer lineRenderer, Vector2 size)
    {
        Vector3 pos = lineRenderer.transform.position;
        Vector3 sizeOffset = new(size.x / 2, 0f, size.y / 2);

        Vector3[] positions =
        {
            pos - sizeOffset + new Vector3(0f, 0f, 0f),
            pos - sizeOffset + new Vector3(size.x, 0f, 0f),
            pos - sizeOffset + new Vector3(size.x, 0f, size.y),
            pos - sizeOffset + new Vector3(0f, 0f, size.y),
        };

        lineRenderer.SetPositions(positions);
    }
}