using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentRaycaster
{
    public static T Raycast<T>(Ray ray) where T : Component
    {
        if (!Physics.Raycast(ray, out RaycastHit hitInfo)) return null;
        var hitGameObject = hitInfo.collider.gameObject;
        if (!hitGameObject.TryGetComponent(out T component)) return null;
        return component;
    }
}
