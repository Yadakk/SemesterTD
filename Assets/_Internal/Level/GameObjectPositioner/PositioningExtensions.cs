using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositioningExtensions
{
    public static Vector3 GetPositionOnTop(this Bounds thisBounds, Bounds targetBounds)
    {
        Vector3 positionOnTop;
        positionOnTop = new(targetBounds.center.x, targetBounds.max.y, targetBounds.center.z);
        positionOnTop.y += thisBounds.extents.y;
        return positionOnTop;
    }
}
