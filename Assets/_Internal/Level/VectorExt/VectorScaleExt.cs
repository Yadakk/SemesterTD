using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorScaleExt
{
    public static Vector3 InverseScale(this Vector3 thisScale, Vector3 scale)
    {
        return new Vector3(
            thisScale.x / scale.x,
            thisScale.y / scale.y,
            thisScale.z / scale.z);
    }
}