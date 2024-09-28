using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedRotation
{
    private readonly Transform target;
    private Vector3 axis;

    private readonly float min;
    private readonly float max;

    private float currentAngle;

    public LimitedRotation(Transform target, Vector3 axis, float min, float max)
    {
        this.target = target;
        this.axis = axis;
        this.min = min;
        this.max = max;
    }

    public void Rotate(float delta)
    {
        currentAngle = Mathf.Clamp(currentAngle + delta, min, max);
        target.localRotation = Quaternion.AngleAxis(currentAngle, axis);
    }

    public void RotateAround(Vector3 point, float delta)
    {
        Rotate(delta);

        float distance = Vector3.Distance(point, target.position);
        target.position = point - (target.forward * distance);
    }
}
